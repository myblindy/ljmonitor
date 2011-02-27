using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

[Serializable]
public class Pair<T, U>
{
    public Pair() { }

    public Pair(T first, U second)
    {
        First = first;
        Second = second;
    }

    public T First { get; set; }
    public U Second { get; set; }
};


public static class LJ
{
    private static object lockobj = new object();

#if MOCKUP
    private static frmMockUp MockUp = new frmMockUp();
#endif

    public static void Init()
    {
#if MOCKUP
        MockUp.Show();
#endif
    }

    public static void Destroy()
    {
#if MOCKUP
        MockUp.Close();
#endif
    }

    public static int ReadDigitalInput(int channel, bool readD)
    {
        if (channel == 0)
            return 0;
#if MOCKUP
        lock (lockobj)
        {
            return MockUp.GetDState(channel - 1) ? 1 : 0;
        }
#else
        lock (lockobj)
        {
            int ljID = 0;
            int state = 0;

            int result = LabJack.EDigitalIn(ref ljID, 0, channel - 1, readD ? 1 : 0, ref state);
            if (result != 0)
                throw new Exception("Error reading digital input");

            return state;
        }
#endif
    }

    public static void SetDigitalOutput(int channel, bool writeD, int state)
    {
        if (channel == 0)
            return;
#if MOCKUP
        lock (lockobj)
        {
            MockUp.SetDState(channel - 1, state != 0);
        }
#else
        lock (lockobj)
        {
            int ljID = 0;

            int result = LabJack.EDigitalOut(ref ljID, 0, channel - 1, writeD ? 1 : 0, state);
            if (result != 0)
                throw new Exception("Error setting digital output");
        }
#endif
    }

    public static long ReadCounter(bool reset)
    {
#if MOCKUP
        return 0;
#else
        lock (lockobj)
        {
            int ljID = 0;
            int stated = 0, stateio = 0;
            uint cnt = 0;

            long result = LabJack.Counter(ref ljID, 0, ref stated, ref stateio,
                reset ? 1 : 0, 0, ref cnt);
            if (result != 0)
                throw new Exception("Error reading the counter");

            return cnt;
        }
#endif
    }

    public static void ReadTemperatureHumidity(out float tempC, out float rh)
    {
#if MOCKUP
        tempC = rh = 0.0f;
#else
        lock (lockobj)
        {
            int ljID = 0;
            tempC = rh = 0.0f;
            float tempF = 0.0f;
            LabJack.SHT1X(ref ljID, 0, 0, 0 /*mode*/, 0 /*status*/,
                ref tempC, ref tempF, ref rh);
        }
#endif
    }

    public static float ReadAnalogInput(int channel)
    {
#if MOCKUP
        return MockUp.GetAState(0);
#else
        lock (lockobj)
        {
            int ljID = 0;
            int overVoltage = 0;
            float voltage = 0.0f;

            int result = LabJack.EAnalogIn(ref ljID, 0, channel, 0, ref overVoltage, ref voltage);
            if (result != 0)
                throw new Exception("Error reading analog input");
            return voltage;
        }
#endif
    }

    public static int ReadDigital()
    {
#if MOCKUP
        lock (lockobj)
        {
            int result = 0;

            for (int p = 1, n = 0; n < 16; ++n, p <<= 1)
                if (MockUp.GetDState(n))
                    result |= p;

            return result;
        }
#else
        lock (lockobj)
        {
            int ljID = 0;
            int outputd = 0;
            int trisd = 0xff00;
            int stateio = 0;
            int stated = 0;

            int res = LabJack.DigitalIO(ref ljID, 0, ref trisd, 0, ref stated, ref stateio,
                0, ref outputd);
            if (res != 0)
                throw new Exception("Error reading digital inputs");

            return stated;
        }
#endif
    }

    public static int ReadIO()
    {
#if MOCKUP
        return 0;
#else
        lock (lockobj)
        {
            int ljID = 0;
            int outputd = 0;
            int trisd = 0xff00;
            int stateio = 0;
            int stated = 0;

            int res = LabJack.DigitalIO(ref ljID, 0, ref trisd, 0, ref stated, ref stateio,
                0, ref outputd);
            if (res != 0)
                throw new Exception("Error reading digital inputs");

            return stateio;
        }
#endif
    }

    public static void ResetOutputs()
    {
        for (int i = 1; i <= 8; ++i)
            SetDigitalOutput(i, true, 0);
    }

    public static bool ValidPin(int pid)
    {
        return pid >= 0 && pid <= 8;
    }

    public static bool ValidPinAny(int pid)
    {
        return pid >= 0 && pid <= 16;
    }

    #region LabJAck
    public class LabJack
    {
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern int AIBurst(ref int idnum, int demo, int stateIOin, int updateIO, int ledOn, int numChannels, [In, Out] int[] channels, [In, Out] int[] gains, ref float scanRate, int disableCal, int triggerIO, int triggerState, int numScans, int timeout, [In, Out] float[,] voltages, [In, Out] int[] stateIOout, ref int overVoltage, int transferMode);
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern int AISample(ref int idnum, int demo, ref int stateIO, int updateIO, int ledOn, int numChannels, [In, Out] int[] channels, [In, Out] int[] gains, int disableCal, ref int overVoltage, [In, Out] float[] voltages);
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern int AIStreamClear(int localID);
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern int AIStreamRead(int localID, int numScans, int timeout, [In, Out] float[,] voltages, [In, Out] int[] stateIOout, ref int reserved, ref int ljScanBacklog, ref int overVoltage);
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern int AIStreamStart(ref int idnum, int demo, int stateIOin, int updateIO, int ledOn, int numChannels, [In, Out] int[] channels, [In, Out] int[] gains, ref float scanRate, int disableCal, int reserved1, int readCount);
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern int AOUpdate(ref int idnum, int demo, int trisD, int trisIO, ref int stateD, ref int stateIO, int updateDigital, int resetCounter, ref uint count, float analogOut0, float analogOut1);
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern int Asynch(ref int idnum, int demo, int portB, int enableTE, int enableTO, int enableDel, int baudrate, int numWrite, int numRead, [In, Out] int[] data);
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern int AsynchConfig(ref int idnum, int demo, int timeoutMult, int configA, int configB, int configTE, int fullA, int fullB, int fullC, int halfA, int halfB, int halfC);
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern int BitsToVolts(int chnum, int chgain, int bits, ref float volts);
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern int Counter(ref int idnum, int demo, ref int stateD, ref int stateIO, int resetCounter, int enableSTB, ref uint count);
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern int DigitalIO(ref int idnum, int demo, ref int trisD, int trisIO, ref int stateD, ref int stateIO, int updateDigital, ref int outputD);
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern int EAnalogIn(ref int idnum, int demo, int channel, int gain, ref int overVoltage, ref float voltage);
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern int EAnalogOut(ref int idnum, int demo, float analogOut0, float analogOut1);
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern int ECount(ref int idnum, int demo, int resetCounter, ref double count, ref double ms);
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern int EDigitalIn(ref int idnum, int demo, int channel, int readD, ref int state);
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern int EDigitalOut(ref int idnum, int demo, int channel, int writeD, int state);
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern float GetDriverVersion();
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern void GetErrorString(int errorCode, StringBuilder errorString);
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern void GetErrorString(int errorcode, [In, Out] char[] errorString);
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern float GetFirmwareVersion(ref int idnum);
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern int GetWinVersion(ref uint majorVersion, ref uint minorVersion, ref uint buildNumber, ref uint platformID, ref uint servicePackMajor, ref uint servicePackMinor);
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern int ListAll([In, Out] int[] productIDList, [In, Out] int[] serialNumList, [In, Out] int[] localIDList, [In, Out] int[] powerList, [In, Out] int[,] calMatrix, ref int numFound, ref int reserved1, ref int reserved2);
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern int LocalID(ref int idnum, int localID);
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern int NoThread(ref int idnum, int noThread);
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern int PulseOut(ref int idnum, int demo, int lowFirst, int bitSelect, int numPulses, int timeB1, int timeC1, int timeB2, int timeC2);
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern int PulseOutCalc(ref float frequency, ref int timeB, ref int timeC);
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern int PulseOutFinish(ref int idnum, int demo, int timeoutMS);
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern int PulseOutStart(ref int idnum, int demo, int lowFirst, int bitSelect, int numPulses, int timeB1, int timeC1, int timeB2, int timeC2);
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern int ReadMem(ref int idnum, int address, ref int data3, ref int data2, ref int data1, ref int data0);
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern int ReEnum(ref int idnum);
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern int Reset(ref int idnum);
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern int ResetLJ(ref int idnum);
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern int SHT1X(ref int idnum, int demo, int softComm, int mode, int statusReg, ref float tempC, ref float tempF, ref float rh);
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern int SHTComm(ref int idnum, int softComm, int waitMeas, int serialReset, int dataRate, int numWrite, int numRead, [In, Out] byte[] datatx, [In, Out] byte[] datarx);
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern int SHTCRC(int statusReg, int numWrite, int numRead, [In, Out] byte[] datatx, [In, Out] byte[] datarx);
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern int Synch(ref int idnum, int demo, int mode, int msDelay, int husDelay, int controlCS, int csLine, int csState, int configD, int numWriteRead, [In, Out] int[] data);
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern int VoltsToBits(int chnum, int chgain, float volts, ref int bits);
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern int Watchdog(ref int idnum, int demo, int active, int timeout, int reset, int activeD0, int activeD1, int activeD8, int stateD0, int stateD1, int stateD8);
        [DllImport("ljackuw.dll", CharSet = CharSet.Ansi)]
        public static extern int WriteMem(ref int idnum, int unlocked, int address, int data3, int data2, int data1, int data0);
    }
    #endregion
}
