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
        int LeGen, Popul, Iter, fanc;
        int Tut; // проверка турника
        public bool Kod = false;

        public bool Ipoint = true;
        int[] point = new int[] { 0 , 0 }; //point1 , point2,
        public double point0;
        
        //Уплотнение сетки
        /////////
        public int DopIter, Setka;
        public bool Set = false;
        /////////
        public double y1, y2, y3,y4;



        float Mut, Inv;

        public float[,] interM = new float[,] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };
        public int Chom=4;

        public string form = "1) (x2 - x1* x1)*(x2 - x1* x1) + (1 - x1)*(1 - x1)" + Environment.NewLine +
            " 4)= 4*(x1 - 5)^2 + (x2 - 6)^2;         (5 ; 6 )   Min=0" + Environment.NewLine +
                             " 5)= (x2 -x1^2)^2 + (1 - x1)^2;           (1 ; 1 )   Min=0 " + Environment.NewLine +
                             "12)= 4*x1^2 + 3*x2^2 - 4*x1*x2^2 + x1     (0 ; 0 )   Min=0 " + Environment.NewLine +
        "15)= (1.5-x1*(1-x2))^2+(2.25-x1*(1-x2^2))^2" + Environment.NewLine + 
                             "     +(2.625 - x1*(1-x2^3))^2;            (3 ; 0,5 ) Min=0 " + Environment.NewLine +
        "17)= 100*(x2 - x1^2)^2 + (1-x1)^2+ " + Environment.NewLine +
        "     90*(x4-x3^2)^2+(1-x3)^2 +10.1((x2 - 1)^2" + Environment.NewLine +
                             "     + (x4-1)^2) + 19.8(x2-1)*(x4-1);     (1; 1; 1; 1) Min=0 ";


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
        public int Itertion
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
