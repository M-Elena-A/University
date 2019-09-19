using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboret_v4
{
    class Parametrs
    {
        // private static int _seed = Environment.TickCount;
        public Random rnd1 = new Random(0);
        int LeGen, Popul,  fanc;
        int Tut; // проверка турника
        public bool Kod = false;
        double Iter;

        public bool Ipoint = true;
        int[] point = new int[] { 0 , 0 }; //point1 , point2,
        public double point0;
        
        //Уплотнение сетки
        /////////
        public int DopIter, Setka;
        public bool Set = false;
        /////////




        float Mut, Inv;

        public float[,] interM = new float[,] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };
        public int Chom=2;

        public string form =
            "1) 100*(x2 - x1* x1)*(x2 - x1* x1) + (1 - x1)*(1 - x1)" + Environment.NewLine +
            "8) x1 * x1 * x1 + x2 * x2 - 3*x1 - 2*x2+2;" + Environment.NewLine +

        "13)= (x1* x1+x2-11)^2+(x1+x2*x2-7)^2" + Environment.NewLine + 
                             
        "16)= (x1 +10*x2)^2 + 5*(x3-x4)^2+ (x2-2*x3)^4+10*(x1-x4)^4 ";


        //xrom_1 = new Chromosom(L);
        //xrom_2 = new Chromosom(L);

        //Min = inter0[0, 0]; //new float[,] { { inter0[0, 0], inter0[0, 1] } };
        //Max = inter0[0, 1];

        public Parametrs()
        {     }
       


        //возможность измененния длины гена
        public int Length
        {
            get
            {
                return LeGen;
            }
            set
            {
                LeGen = value;
            }
        }
        public int Popultion
        {
            get
            {
                return Popul;
            }
            set
            {
                Popul = value;
            }
        }
        public double Itertion
        {
            get
            {
                return Iter;
            }
            set
            {
                Iter = value;
            }
        }
        public float Muttion
        {
            get
            {
                return Mut;
            }
            set
            {
                Mut = value;
            }
        }
        public float Invtion
        {
            get
            {
                return Inv;
            }
            set
            {
                Inv = value;
            }
        }
        public int point1
        {
            get
            {
                return point[0];
            }
            set
            {
                point[0] = value;
            }
        }
        public int point2
        {
            get
            {
                return point[1];
            }
            set
            {
                point[1] = value;
            }
        }
        public int Tutu
        {
            get
            {
                return Tut;
            }
            set
            {
                Tut = value;
            }
        }
        public int Fanc
        {
            get
            {
                return fanc;
            }
            set
            {
                fanc = value;
            }
        }
        
        

    }
}
