using System.Security.Cryptography.X509Certificates;

internal class Program
{
    public enum Kelurahan
    {
        Batununggal,
        Kujangsari,
        Mengger,
        Wates,
        Cijaura,
        Jatisari,
        Margasari,
        Sekejati,
        Kebonwaru,
        Maleer,
        Samoja
    }

    public enum DoorState
    {
        TERKUNCI, TERBUKA
    }

    public enum Trigger
    {
        KUNCI_PINTU, BUKA_PINTU
    }

    public class KodePos
    {
        public static int getKodePos_1302213089(Kelurahan inputKelurahan)
        {
            int[] outputKodePos = { 40266, 40287, 40267, 40256, 40287, 40286, 40286, 40286, 40272, 40274, 40273 };
            int inputInt = (int)inputKelurahan;
            return outputKodePos[inputInt];
        }
    }

    public class DoorMachine
    {
        public DoorState currentState = DoorState.TERKUNCI;
        public class Transition
        {
            public DoorState stateAwal;
            public DoorState stateAkhir;
            public Trigger trigger;

            public Transition(DoorState stateAwal, DoorState stateAkhir, Trigger trigger)
            {
                this.stateAwal = stateAwal;
                this.stateAkhir = stateAkhir;
                this.trigger = trigger;
            }
        }

        Transition[] transisi =
        {
            new Transition(DoorState.TERKUNCI, DoorState.TERBUKA, Trigger.BUKA_PINTU),
            new Transition(DoorState.TERBUKA, DoorState.TERKUNCI, Trigger.KUNCI_PINTU),
            new Transition(DoorState.TERKUNCI, DoorState.TERKUNCI, Trigger.KUNCI_PINTU),
            new Transition(DoorState.TERBUKA, DoorState.TERBUKA, Trigger.BUKA_PINTU)
        };

        private DoorState GetStateBerikutnya_1302213089(DoorState stateAwal, Trigger trigger)
        {
            DoorState stateAkhir = stateAwal;

            for(int i = 0; i < transisi.Length; i++)
            {
                Transition perubahan = transisi[i];

                if(stateAwal == perubahan.stateAwal && trigger == perubahan.trigger)
                {
                    stateAkhir = perubahan.stateAkhir;
                }
                
            }
            return stateAkhir;
        }
        public void ActivateTrigger_1302213089(Trigger trigger)
        {
            currentState = GetStateBerikutnya_1302213089(currentState, trigger);

            Console.WriteLine("State sekarang adalah : " + currentState);

            if(currentState == DoorState.TERKUNCI)
            {
                Console.WriteLine("Pintu Terkunci");
            } else if(currentState == DoorState.TERBUKA)
            {
                Console.WriteLine("Pintu Terbuka");
            }
        }
    }


    private static void Main(string[] args)
    {
        Kelurahan kel = Kelurahan.Mengger;
        int kodepos = KodePos.getKodePos_1302213089(kel);
        Console.WriteLine("Kelurahan " + kel + " memiliki kode pos : " + kodepos+"\n");

        DoorMachine objDoor = new DoorMachine();
        DoorState firstState = DoorState.TERKUNCI;

        Console.WriteLine("State awal adalah : " + firstState);
        if (firstState == DoorState.TERKUNCI)
        {
            Console.WriteLine("Pintu Terkunci" + "\n");
        }
        else if (firstState == DoorState.TERBUKA)
        {
            Console.WriteLine("Pintu Terbuka" + "\n");
        }

        objDoor.ActivateTrigger_1302213089(Trigger.BUKA_PINTU);
        objDoor.ActivateTrigger_1302213089(Trigger.KUNCI_PINTU);
        objDoor.ActivateTrigger_1302213089(Trigger.KUNCI_PINTU);
    }
}

