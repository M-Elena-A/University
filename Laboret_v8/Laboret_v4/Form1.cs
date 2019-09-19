using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Collections;

namespace Laboret_v4
{
    public partial class Form1 : Form
    {
        
        Parametrs Aa = new Parametrs();
        double x1, x2;

        public Form1()
        {
            InitializeComponent();

            help_box(); 
           
        }

        private void Int_Nomb(object sender, KeyPressEventArgs e)
        { char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44 && number != 45) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }
        private void Mutation_KeyPress(object sender, KeyPressEventArgs e)
        { Int_Nomb(sender, e); }
        private void Inversion_KeyPress(object sender, KeyPressEventArgs e)
        { Int_Nomb(sender, e); }
        private void VerPoint_KeyPress(object sender, KeyPressEventArgs e)
        { Int_Nomb(sender, e); }
        private void сохранитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            сохранить( sender,  e);
        }
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            сохранить(sender, e);
        }
        private void сохранить(object sender, EventArgs e)
        {
           
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
            
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {string filename = saveFileDialog1.FileName;

              System.IO.File.WriteAllText(filename, MtextBox.Text); 
            }
            


        }
        ///////////////////////////////////////////////////////////////////////////      

        
        private void button1_Click(object sender, EventArgs e)
        {
            Set_param();
            //  Test_Chrom();
            //  Test_Individ();
            // 
            //Test_VeshCr();
            // Test_VeshInd();


            


            if (Aa.Kod)
            Test_VeshPopultion();
           else 
            if (!Aa.Set) Test_Popultion();
           else Test_Popultion2();


            if (checkBox5.Checked)
                XD();// метод хука ждивса
            /// checkBox5 метод ХД
            
        }
        //вещественная кодировка
        private void Test_VeshPopultion()
        {
            VeshPopulation test = new VeshPopulation(Aa);
            // создание популяции


            //int Namber0, int nIters0, double pMut0, double pInv0
            // (  (int L, float Mut, float Inv, int point, int point2, int Namber0, int nIters0)


            VeshIndivid test_Ind = test.Turnir(test.Popul_all);

            // MtextBox.Text = MtextBox.Text + "------- + 0 + -------" + Environment.NewLine;
            // MtextBox.Text = MtextBox.Text + test.Print( point,  point2) + Environment.NewLine;
            // MtextBox.Text = MtextBox.Text + test_Ind.Fank_out + Environment.NewLine;
            // MtextBox.Text = MtextBox.Text + test_Ind.Prin_Fen(Aa) + Environment.NewLine;


            MtextBox.Text = MtextBox.Text + "------- + 0 + -------" + Environment.NewLine
              //  + test.Print(Aa)  //;
              + Environment.NewLine + "Min  " + test_Ind.Fank_out + Environment.NewLine;

            double minu;
            for (int i = 0; i < 50; i++) //Aa.Itertion
            {
                minu = test.TurnirMax(test.Popul_all).Fank_out - test.Turnir(test.Popul_all).Fank_out;
                if (minu > Aa.Itertion)
                {
                    test.Select(Aa);
                    test_Ind = test.Turnir(test.Popul_all);

                    MtextBox.Text = MtextBox.Text + //"-------" + (i+1) + "-------" + Environment.NewLine +
                                                    // test.Print(point, point2)+ Environment.NewLine + "-----" + Environment.NewLine +
                                                    // test_Ind.Fank_out + Environment.NewLine;
                                                    // test.Print(Aa) + Environment.NewLine + 
                    "Min " + (i + 1) + "       " + test_Ind.Fank_out + Environment.NewLine;
                    test.Mut_all(Aa);
                    //MtextBox.Text = MtextBox.Text + test_Ind.Prin_Fen() + Environment.NewLine;
                }
                else
                    break;
            }

            //test_Ind = test.Turnir(test.Popul_all);
            MtextBox.Text = MtextBox.Text + "-------END-------" + Environment.NewLine +
            // test.Print(point, point2) + Environment.NewLine + "-----" +
            Environment.NewLine + test_Ind.Prin_Fen(Aa) + Environment.NewLine;
            // MtextBox.Text = MtextBox.Text + test_Ind.Prin_Fen() + Environment.NewLine;

            MtextBox.Text = MtextBox.Text + "-------------" + Environment.NewLine +
           test_Ind.xrom[0].Prin() + Environment.NewLine + test_Ind.xrom[1].Prin() + Environment.NewLine;

            /////для 4 
            x1 = test_Ind.xrom[0].chrom;
            x2 = test_Ind.xrom[1].chrom;

        }
       
        
        // целочисленная кодировка
        private void Test_Popultion()
        {
            Population test = new Population(Aa);
            // создание популяции


            //int Namber0, int nIters0, double pMut0, double pInv0
            // (  (int L, float Mut, float Inv, int point, int point2, int Namber0, int nIters0)


            Individ test_Ind = test.Turnir2(test.Popul_all);

            // MtextBox.Text = MtextBox.Text + "------- + 0 + -------" + Environment.NewLine;
            // MtextBox.Text = MtextBox.Text + test.Print( point,  point2) + Environment.NewLine;
            // MtextBox.Text = MtextBox.Text + test_Ind.Fank_out + Environment.NewLine;
            // MtextBox.Text = MtextBox.Text + test_Ind.Prin_Fen(Aa) + Environment.NewLine;

            Pr_param();
            MtextBox.Text = MtextBox.Text + "------- + 0 + -------" + Environment.NewLine
              //  + test.Print(Aa)  //;
              + Environment.NewLine+ "Min  " + test_Ind.Fank_out+Environment.NewLine;
            double minu;
            for (int i = 0; i < 50; i++) //Aa.Itertion
            {
                minu = test.TurnirMax(test.Popul_all).Fank_out - test.Turnir2(test.Popul_all).Fank_out;
                if ( minu >  Aa.Itertion)
                {
                    test.Mut_all(Aa);
                    test.Select(Aa);
                    test_Ind = test.Turnir2(test.Popul_all);

                   // MtextBox.Text = MtextBox.Text + test.Print(Aa);
                    MtextBox.Text = MtextBox.Text +
                       "max в популяции "+ test.TurnirMax(test.Popul_all).Fank_out + Environment.NewLine +
                       "min в популяции " + test.Turnir2(test.Popul_all).Fank_out + Environment.NewLine;

                    MtextBox.Text = MtextBox.Text + //"-------" + (i+1) + "-------" + Environment.NewLine +
                                                    // test_Ind.Fank_out + Environment.NewLine+//;
                                                    // test.Print(Aa) + Environment.NewLine + 
                    "Min " + (i + 1) + "       " + test_Ind.Fank_out + Environment.NewLine;
                    test.Mut_all(Aa);
                    //MtextBox.Text = MtextBox.Text + test_Ind.Prin_Fen() + Environment.NewLine;
                }
                else
                    break;
            }
            
            //test_Ind = test.Turnir(test.Popul_all);
            MtextBox.Text = MtextBox.Text + "-------END-------" + Environment.NewLine +
           // test.Print(point, point2) + Environment.NewLine + "-----" +
            Environment.NewLine + test_Ind.Prin_Fen(Aa) + Environment.NewLine;
            // MtextBox.Text = MtextBox.Text + test_Ind.Prin_Fen() + Environment.NewLine;

            MtextBox.Text = MtextBox.Text + "-------------" + Environment.NewLine +
           test_Ind.xrom[0].Prin(Aa)   + Environment.NewLine + test_Ind.xrom[1].Prin(Aa) + Environment.NewLine;

            /////для 4 
            x1 = test_Ind.Fenotip_1(Aa);
            x2 = test_Ind.Fenotip_2(Aa);

        }

        // целочисленная кодировка  с уплотнением сетки
        private void Test_Popultion2()
        {
            
            Population test = new Population(Aa);
            // создание популяции
            int i;

            //int Namber0, int nIters0, double pMut0, double pInv0
            // (  (int L, float Mut, float Inv, int point, int point2, int Namber0, int nIters0)


            Individ test_Ind = test.Turnir2(test.Popul_all);

            // MtextBox.Text = MtextBox.Text + "------- + 0 + -------" + Environment.NewLine;
            // MtextBox.Text = MtextBox.Text + test.Print( point,  point2) + Environment.NewLine;
            // MtextBox.Text = MtextBox.Text + test_Ind.Fank_out + Environment.NewLine;
            // MtextBox.Text = MtextBox.Text + test_Ind.Prin_Fen(Aa) + Environment.NewLine;

            Pr_param();
            MtextBox.Text = MtextBox.Text + "------- + 0 + -------" + Environment.NewLine
              //  + test.Print(Aa)  //;
              + Environment.NewLine + "Min  " + test_Ind.Fank_out + Environment.NewLine;

            double minu;
            for (i = 0; i < Aa.DopIter; i++) //Aa.Itertion
            {
                minu = test.TurnirMax(test.Popul_all).Fank_out - test.Turnir2(test.Popul_all).Fank_out;
                if ((minu > Aa.Itertion))
                {

                    test.Mut_all(Aa);
                    test.Select(Aa);
                    test_Ind = test.Turnir2(test.Popul_all);

                    MtextBox.Text = MtextBox.Text + //"-------" + (i+1) + "-------" + Environment.NewLine +
                                                    // test.Print(point, point2)+ Environment.NewLine + "-----" + Environment.NewLine +
                                                    // test_Ind.Fank_out + Environment.NewLine;
                                                    // test.Print(Aa) + Environment.NewLine + 
                    "Min " + (i + 1) + "       " + test_Ind.Fank_out + Environment.NewLine;
                    test.Mut_all(Aa);
                    //MtextBox.Text = MtextBox.Text + test_Ind.Prin_Fen() + Environment.NewLine;

                }
                else
                    break;
            }

          
            Aa.Length = Aa.Length * Aa.Setka;
            Population test2 = new Population(Aa);
            test2.Copi(Aa, test);
            Individ test_Ind2 = test2.Turnir2(test2.Popul_all);
            Aa.point1 = Aa.point1* Aa.Setka;
            Aa.point2 = Aa.point2* Aa.Setka;


            for (i = Aa.DopIter; i < 50; i++)
            {
                minu = test.TurnirMax(test.Popul_all).Fank_out - test.Turnir2(test.Popul_all).Fank_out;
                if ((minu > Aa.Itertion) )
                {
                    test2.Mut_all(Aa);
                test2.Select(Aa);
                test_Ind2 = test2.Turnir2(test2.Popul_all);

                MtextBox.Text = MtextBox.Text + //"-------" + (i+1) + "-------" + Environment.NewLine +
                                                // test.Print(point, point2)+ Environment.NewLine + "-----" + Environment.NewLine +
                                                // test_Ind.Fank_out + Environment.NewLine;
                                                // test.Print(Aa) + Environment.NewLine + 
                "Min " + (i + 1) + "       " + test_Ind2.Fank_out + Environment.NewLine;
                test2.Mut_all(Aa);
                    //MtextBox.Text = MtextBox.Text + test_Ind.Prin_Fen() + Environment.NewLine;
                }
                else
                    break;
            }



            //test_Ind = test.Turnir(test.Popul_all);
            MtextBox.Text = MtextBox.Text + "-------END-------" + Environment.NewLine +
            // test.Print(point, point2) + Environment.NewLine + "-----" +
            Environment.NewLine + test_Ind2.Prin_Fen(Aa) + Environment.NewLine;
            // MtextBox.Text = MtextBox.Text + test_Ind.Prin_Fen() + Environment.NewLine;

            MtextBox.Text = MtextBox.Text + "-------------" + Environment.NewLine +
           test_Ind2.xrom[0].Prin(Aa) + Environment.NewLine + test_Ind2.xrom[1].Prin(Aa) + Environment.NewLine;


            /////для 4 
            x1 = test_Ind2.Fenotip_1(Aa);
            x2 = test_Ind2.Fenotip_2(Aa);

        }

       
        // установление всех параметров
        private void Pr_param()
        {
            MtextBox.Text = MtextBox.Text + "Ген " + LengthGene.Text +
                "    Мутация " + Mutation.Text + "    Инверсия " + Inversion.Text + Environment.NewLine;

            if (Aa.Chom == 2)
                MtextBox.Text = MtextBox.Text + "Интервал  "+
                " (" + min_x1.Text + ";" + max_x1.Text + ")   " + 
                " (" + min_x2.Text + ";" + max_x2.Text + ") " + Environment.NewLine;
            else
            MtextBox.Text = MtextBox.Text + "Интервал  " +
                " (" + min_x1.Text + ";" + max_x1.Text + ")   "  +
                 " (" + min_x2.Text + ";" + max_x2.Text + ") " + Environment.NewLine +
                 " (" + min_x3.Text + ";" + max_x3.Text + ")   " +
                 " (" + min_x4.Text + ";" + max_x4.Text + ") " + Environment.NewLine;
               
             
            if (Aa.Kod)
                MtextBox.Text = MtextBox.Text+"Вещественная кодировка";
            else
                MtextBox.Text = MtextBox.Text+"Целочисленная кодировка";

        }

        private void Set_param()
        {
            Aa.Length = Convert.ToInt32(LengthGene.Text);   // длина гена

            Aa.Muttion  = float.Parse(Mutation.Text);   // мутация
            Aa.Invtion = float.Parse(Inversion.Text);   // инверсия

          

            //проверка
            if ( Convert.ToInt32(Population.Text) % 2 > 0)
                Aa.Popultion = Convert.ToInt32(Population.Text)+1;   // количество особей популяции
            else Aa.Popultion = Convert.ToInt32(Population.Text);
            //проверка
            if (Aa.Popultion < 10)
                Aa.Tutu= 2;   // количество особей популяции
            else
                Aa.Tutu  = Convert.ToInt32(comboBox1.Text);

            Aa.Itertion = float.Parse(Iteration.Text);    // кол итераций
            Aa.Fanc = Convert.ToInt32(fanction_Ch.Text);   // функция
                                                                //MtextBox.Text = MtextBox.Text + fanction_Ch.Text;

            
            // поисковый интервал
            
            
            // количество Х 
            if (Aa.Chom == 2)
            Aa.interM = new float[,] { {float.Parse(min_x1.Text) ,float.Parse(max_x1.Text) },
            {float.Parse(min_x2.Text) ,float.Parse(max_x2.Text) },};
            if (Aa.Chom == 4)
            Aa.interM = new float[,] { 
            {float.Parse(min_x1.Text) ,float.Parse(max_x1.Text) },
            {float.Parse(min_x2.Text) ,float.Parse(max_x2.Text) },
            {float.Parse(min_x3.Text) ,float.Parse(max_x3.Text) },
            {float.Parse(min_x4.Text) ,float.Parse(max_x4.Text) }, };

            // точки  Следить что бы р1 был меньше р2
            Aa.Ipoint = checkBox1.Checked;
            Aa.point0 = float.Parse(VerPoint.Text);
            if (float.Parse(VerPoint.Text) == 0.5) Aa.Ipoint = false;

            if (Aa.Ipoint)
            {
                if (float.Parse(VerPoint.Text) < 0.5)
                {
                    Aa.point1 =(int)Math.Floor(Aa.Length * float.Parse(VerPoint.Text));    // точка скрещивания
                    Aa.point2 =(int)Math.Floor(Aa.Length * (1 - float.Parse(VerPoint.Text)));
                }
                else
                {
                    Aa.point2 =(int)Math.Floor(Aa.Length * float.Parse(VerPoint.Text));    // точка скрещивания
                    Aa.point1 =(int)Math.Floor(Aa.Length * (1 - float.Parse(VerPoint.Text)));
                }
            }

            else
            {
                Aa.point1 = (int)Math.Floor(Aa.Length * float.Parse(VerPoint.Text));    // точка скрещивания
                Aa.point2 = 0;
            }

            /*
           if (checkBox2.Checked)
           {
               MtextBox.Text = MtextBox.Text + Aa.Chom + Environment.NewLine
               + Aa.interM[0, 0] + Aa.interM[0, 1] + Aa.interM[1, 0] + Aa.interM[1, 1] + Environment.NewLine
               + Aa.interM[2, 0] + Aa.interM[2, 1] + Aa.interM[3, 0] + Aa.interM[3, 1];
           }
           */
            Aa.Kod = checkBox3.Checked;



            Aa.Set=checkBox4.Checked;
            Aa.DopIter=Convert.ToInt32(Dopit.Text);
            Aa.Setka = Convert.ToInt32(Setka.Text);
            
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox2.Checked)
            {
                Aa.Chom = 4;
                min_x3.Enabled = true;
                max_x3.Enabled = true;
                min_x4.Enabled = true;
                max_x4.Enabled = true;
            }
            else
            {
                Aa.Chom = 2;
                min_x3.Enabled = false;
                max_x3.Enabled = false;
                min_x4.Enabled = false;
                max_x4.Enabled = false;
            }
            help_box();

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Aa.Ipoint = checkBox1.Checked;
            help_box();
                    }       
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            Aa.Kod = checkBox3.Checked;
            help_box();
        }       
        private void button2_Click(object sender, EventArgs e)
        {
            MtextBox.Text = "";

            //Set_param();
            //Test_Individ();
        }
        private void help_box()
        {
            if (Aa.Kod)
                Help_textBox.Text = "Вещественная кодировка";
            else
                Help_textBox.Text = "Целочисленная кодировка";

            if (Aa.Chom == 2)
                Help_textBox.Text = Help_textBox.Text + Environment.NewLine + "Две переменных (хром)";
            else
                Help_textBox.Text = Help_textBox.Text + Environment.NewLine + "Четыре переменных (хром)";


            if (Aa.Ipoint)
                Help_textBox.Text = Help_textBox.Text + Environment.NewLine + "Две точки скрещивания";
            else
                Help_textBox.Text = Help_textBox.Text + Environment.NewLine + "Одна точка скрещивания";



            Help_textBox.Text = Help_textBox.Text + Environment.NewLine + Environment.NewLine + Aa.form;

        }


        private void XD()
        {
            //test_Ind;
            VeshIndivid t0, t1, t2, t3, t4;
            t0 =  new VeshIndivid(Aa);
             t1 = new VeshIndivid(Aa);
              t2 =  new VeshIndivid(Aa);
               t3 = new VeshIndivid(Aa);
                t4 = new VeshIndivid(Aa);
            double f, f0, alf = 0.1;
            int pr = 0;
            VeshPopulation F = new VeshPopulation(Aa);

            // t0.xrom[0]= test_Ind
            /////для 4 
            t0.xrom[0].chrom = x1;
            t0.xrom[1].chrom = x2;

            f0 = t0.Fank_out = F.Fank_(t0, Aa);
            MtextBox.Text = MtextBox.Text + Environment.NewLine
                + f0 + Environment.NewLine;
            ////



            for (int i = 0; i < 1000 && pr != 1; i++)
            {
                t1.xrom[0].chrom = t0.Fenotip_1(Aa) + alf;
                t1.xrom[1].chrom = t0.Fenotip_2(Aa);
                t1.Fank_out = F.Fank_(t1, Aa);

                if (Math.Abs(t1.Fank_out) < Math.Abs(t0.Fank_out))
                {
                    t2.xrom[0].chrom = t0.xrom[0].chrom + alf;
                    t2.xrom[1].chrom = t0.xrom[1].chrom + alf;
                    t2.Fank_out = F.Fank_(t2, Aa);

                    if (Math.Abs(t2.Fank_out) < Math.Abs(t1.Fank_out))
                    {
                        t0.xrom[0].chrom = t2.xrom[0].chrom;
                        t0.xrom[1].chrom = t2.xrom[1].chrom;

                        f0 = t0.Fank_out = t2.Fank_out;
                    }
                    else
                    {
                        t3.xrom[0].chrom = t0.xrom[0].chrom + alf;
                        t3.xrom[1].chrom = t0.xrom[1].chrom - alf;
                        t3.Fank_out = F.Fank_(t3, Aa);

                        if (Math.Abs(t3.Fank_out) < Math.Abs(t1.Fank_out))
                        {
                            t0.xrom[0].chrom = t3.xrom[0].chrom;
                            t0.xrom[1].chrom = t3.xrom[1].chrom;

                            f0 = t0.Fank_out = t3.Fank_out;
                        }
                        else
                        {
                            t0.xrom[0].chrom = t1.xrom[0].chrom;
                            t0.xrom[1].chrom = t1.xrom[1].chrom;

                            f0 = t0.Fank_out = t1.Fank_out;
                        }
                    }


                }
                else
                {
                    t2.xrom[0].chrom = t0.xrom[0].chrom - alf;
                    t2.xrom[1].chrom = t0.xrom[1].chrom;
                    t2.Fank_out = F.Fank_(t2, Aa);
                    if (Math.Abs(t2.Fank_out) < Math.Abs(t0.Fank_out))
                    {

                        t3.xrom[0].chrom = t0.xrom[0].chrom - alf;
                        t3.xrom[1].chrom = t0.xrom[1].chrom + alf;
                        t3.Fank_out = F.Fank_(t3, Aa);

                        if (Math.Abs(t3.Fank_out) < Math.Abs(t2.Fank_out))
                        {
                            t0.xrom[0].chrom = t3.xrom[0].chrom;
                            t0.xrom[1].chrom = t3.xrom[1].chrom;

                            f0 = t0.Fank_out = t3.Fank_out;
                        }
                        else
                        {
                            t4.xrom[0].chrom = t0.xrom[0].chrom - alf;
                            t4.xrom[1].chrom = t0.xrom[1].chrom - alf;
                            t4.Fank_out = F.Fank_(t4, Aa);

                            if (Math.Abs(t4.Fank_out) < Math.Abs(t2.Fank_out))
                            {
                                t0.xrom[0].chrom = t4.xrom[0].chrom;
                                t0.xrom[1].chrom = t4.xrom[1].chrom;

                                f0 = t0.Fank_out = t4.Fank_out;
                            }
                            else
                            {
                                t0.xrom[0].chrom = t2.xrom[0].chrom;
                                t0.xrom[1].chrom = t2.xrom[1].chrom;

                                f0 = t0.Fank_out = t2.Fank_out;
                            }

                        }

                    }// 2+
                    else //2-
                    {
                        t3.xrom[0].chrom = t0.xrom[0].chrom;
                        t3.xrom[1].chrom = t0.xrom[1].chrom + alf;
                        t3.Fank_out = F.Fank_(t3, Aa);
                        if (Math.Abs(t3.Fank_out ) < Math.Abs(t0.Fank_out))
                        {
                            t0.xrom[0].chrom = t3.xrom[0].chrom;
                            t0.xrom[1].chrom = t3.xrom[1].chrom;

                            f0 = t0.Fank_out = t3.Fank_out;
                        }
                        else
                        {
                            t4.xrom[0].chrom = t0.xrom[0].chrom;
                            t4.xrom[1].chrom = t0.xrom[1].chrom - alf;
                            t4.Fank_out = F.Fank_(t4, Aa);
                            if (Math.Abs(t4.Fank_out) < Math.Abs(t0.Fank_out))
                            {
                                t0.xrom[0].chrom = t4.xrom[0].chrom;
                                t0.xrom[1].chrom = t4.xrom[1].chrom;

                                f0 = t0.Fank_out = t4.Fank_out;
                            }
                            else pr = 1;//
                        }
                    }
                    //els -1
                }

                if (pr == 1)
                { alf = alf / 10;
                    if (alf > 0.000001)
                    pr = 0;
                }
            }

            MtextBox.Text = MtextBox.Text + Environment.NewLine
                    + f0 + Environment.NewLine;

            MtextBox.Text = MtextBox.Text + 
           t0.xrom[0].Prin() + Environment.NewLine + t0.xrom[1].Prin() + Environment.NewLine;




        }




        // проверка работоспособности
        //вещественная кодировка
        private void Test_VeshCr()
        {
            VeshChrom Te1, Te2;
            Te1 = new VeshChrom(Aa, 0);
            Te2 = new VeshChrom(Aa, 1);

            MtextBox.Text = MtextBox.Text + "-------------" + Environment.NewLine +
          Te1.Prin() + Environment.NewLine + Te2.Prin() + Environment.NewLine;

        }
        private void Test_VeshInd()
        {
            VeshIndivid Te1, Te2;
            VeshIndivid[] Te = new VeshIndivid[2];
            Te[0] = new VeshIndivid(Aa);
            Te[1] = new VeshIndivid(Aa);

            Te1 = new VeshIndivid(Aa);
            Te2 = new VeshIndivid(Aa);

            MtextBox.Text = MtextBox.Text + "-------------" + Environment.NewLine +
          Te1.Prin_Ind(Aa) + Environment.NewLine + Te2.Prin_Ind(Aa) + Environment.NewLine;

            Te = VeshIndivid.PointCrossOver(Aa, Te1, Te2);

            MtextBox.Text = MtextBox.Text +
           Te[0].Prin_Ind(Aa) + Environment.NewLine + Te[1].Prin_Ind(Aa) + Environment.NewLine;


        }

        // целочисленная кодировка      
        private void Test_Individ()
        {
            /*int LeGen = Convert.ToInt32(LengthGene.Text);
            float Mut = float.Parse(Mutation.Text);
            float Inv = float.Parse(Inversion.Text);
            int point = (int)Math.Floor(LeGen * float.Parse(VerPoint.Text));
            int point2 = 0; // (int)Math.Floor(LeGen * (1 - float.Parse(VerPoint.Text)));
            //Следить что бы р1 был меньше р2
            */

            Individ test_Ind1 = new Individ(Aa);
            Individ test_Ind2 = new Individ(Aa);

            MtextBox.Text = MtextBox.Text + "Особь 1" + Environment.NewLine + test_Ind1.Prin_Ind(Aa) + Environment.NewLine;
            MtextBox.Text = MtextBox.Text + "-------------" + Environment.NewLine;
            MtextBox.Text = MtextBox.Text + "Особь 2" + Environment.NewLine + test_Ind2.Prin_Ind(Aa) + Environment.NewLine;
            MtextBox.Text = MtextBox.Text + "-------------" + Environment.NewLine;

            MtextBox.Text = MtextBox.Text + "Особь 1" + Environment.NewLine + test_Ind1.Prin_Fen(Aa) + Environment.NewLine;
            MtextBox.Text = MtextBox.Text + "Особь 2" + Environment.NewLine + test_Ind2.Prin_Fen(Aa) + Environment.NewLine;
            MtextBox.Text = MtextBox.Text + "-------------" + Environment.NewLine;

            //проверка на поинт2 и его наличие если 0 то 1 точечное
            Individ[] C = Individ.PointCrossOver(Aa, test_Ind1, test_Ind2);
            string ind = "";
            for (int i = 0; i < C.Length; i++)
            {
                ind = ind + "Потомок " + (i + 1) + Environment.NewLine + C[i].Prin_Ind(Aa) + Environment.NewLine;
                ind = ind + "Потомок " + (i + 1) + Environment.NewLine + C[i].Prin_Fen(Aa) + Environment.NewLine;
            }
            MtextBox.Text = MtextBox.Text + ind + Environment.NewLine;

        }
        private void Test_Chrom()
        {

            Chromosom test1 = new Chromosom(Aa);
            Chromosom test2 = new Chromosom(Aa);
            Chromosom test3 = new Chromosom(Aa);
            Chromosom test4 = new Chromosom(Aa);



            MtextBox.Text = MtextBox.Text + Environment.NewLine + "1)" + test1.Prin(Aa) + "   2)" + test2.Prin(Aa) + Environment.NewLine;
            MtextBox.Text = MtextBox.Text + "3)" + test3.Prin(Aa);
            MtextBox.Text = MtextBox.Text + "   4)" + test4.Prin(Aa) + Environment.NewLine;

            MtextBox.Text = MtextBox.Text + TestGenot_in_Fenotip(test1) + "  " + TestGenot_in_Fenotip(test2) + Environment.NewLine;
            MtextBox.Text = MtextBox.Text + TestGenot_in_Fenotip(test3) + "  " + TestGenot_in_Fenotip(test4) + Environment.NewLine;

            Chromosom.PointCrossOver(Aa, test1, test2, out test3, out test4);

            MtextBox.Text = MtextBox.Text + "3)" + test3.Prin(Aa);
            MtextBox.Text = MtextBox.Text + "   4)" + test4.Prin(Aa) + Environment.NewLine;

            MtextBox.Text = MtextBox.Text + TestGenot_in_Fenotip(test1) + "  " + TestGenot_in_Fenotip(test2) + Environment.NewLine;
            MtextBox.Text = MtextBox.Text + TestGenot_in_Fenotip(test3) + "  " + TestGenot_in_Fenotip(test4) + Environment.NewLine;




        }

        double TestGenot_in_Fenotip(Chromosom ch)
        {
            Int32 gen = 0;
            for (int i = 0; i < Chromosom.Length; i++)
            {
                if (ch[i])
                    gen += 1 << i;
            }
            return Aa.interM[0, 0] + gen * (Aa.interM[0, 1] - Aa.interM[0, 0]) / (Math.Pow(2.0, Chromosom.Length) - 1);
            //Min + gen * (Max - Min) / (Math.Pow(2.0, Chromosom.Length) - 1);
        }

    }
}
