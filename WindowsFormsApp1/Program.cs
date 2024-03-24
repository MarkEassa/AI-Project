

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public class Croute
    {
        public int X, Y;

        public Color clr;


    }
    public class Goal
    {
        public int X, Y;
        public int W, H, hrg;
        public Bitmap img;

    }
    public class Hero
    {
        public int X, Y;
        public int W, H;
        public Bitmap img;

    }
    public class CNode
    {
        public int X, Y;
        public int W, H, hr, cost;
        public Color clr;
        public int IsChecked, gothero, gotgoal, iscolored, id, parentid, attachid = 1000, attachidd = -9999, greedytotal;
        public CNode right = null, left = null, up = null, down = null;


    }
    public class Clist
    {

        public CNode phead;
        public CNode ptail;

        public Clist()
        {
            phead = null;
            ptail = null;
        }
        public void Attach(CNode pnn)
        {

            if (phead == null)
            {
                phead = ptail = pnn;
            }
            else
            {
                pnn.left = ptail;
                ptail.right = pnn;
                ptail = pnn;

            }

        }

        void Dispall()
        {
            CNode ptrav = phead;
            while (ptrav != null)
            {

                ptrav = ptrav.right;
            }
        }
        public void remove(Clist X)
        {

            if (phead != ptail)
            {




            }


        }
    };


    class Program : Form
    {
        int SecondRand, FirstRand, costr, hrr, pp1 = 505, pp2 = 205, ct, ct2, at, min = 9999999, max = -9999;
        int ct1 = 0;

        Clist L;
        CNode Pr, nm = new CNode();
        // List<CActor> list = new List<CActor>();
        List<Hero> LHero = new List<Hero>();
        List<Goal> Lgoal = new List<Goal>();
        List<Croute> route = new List<Croute>();
        //  List<CActor> l2 = new List<CActor>();



        Program()
        {
            this.WindowState = FormWindowState.Maximized;
            this.KeyDown += Program_KeyDown;
            this.Paint += Program_Paint;
            this.Load += Program_Load;
            this.MouseClick += Program_MouseClick;
        }

        private void Program_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            CNode Pl = new CNode();
            if (e.X < 505 || e.X > 1100 || e.Y < 200 || e.Y > 600)
            {
                MessageBox.Show("PLEASE CLICK INSIDE THE RED BOX");
            }


            if (ct1 == 0)
            {
                Hero ptr = new Hero();

                Pl = L.phead;
                while (Pl != null)
                {
                    if (e.X > Pl.X && Pl.X + Pl.W > e.X && e.Y > Pl.Y && Pl.Y + Pl.H > e.Y && Pl.iscolored == 0)
                    {
                        ptr.X = Pl.X;
                        ptr.Y = Pl.Y;
                        Pl.IsChecked = 1;
                        Pl.gothero = 1;

                        ct1 = 1;
                    }




                    Pl = Pl.right;
                }
                if (ct1 == 1)
                {
                    ptr.img = new Bitmap("alien.bmp");
                    ptr.img.MakeTransparent(ptr.img.GetPixel(0, 0));
                    ptr.W = ptr.img.Width;
                    ptr.H = ptr.img.Height;
                    LHero.Add(ptr);
                    DrawScene(g);
                    MessageBox.Show("PLEASE CLICK TO CHOOSE THE GOAL'S POSITION");

                }
                else if (ct1 == 0)
                {
                    MessageBox.Show("plz click on the block itself");

                }

            }

            else if (ct1 == 1)
            {

                Goal ptr = new Goal();
                ptr.hrg = 0;
                Pl = L.phead;

                while (Pl != null)
                {
                    if (e.X > Pl.X && Pl.X + Pl.W > e.X && e.Y > Pl.Y && Pl.Y + Pl.H > e.Y && Pl.iscolored == 0)
                    {

                        ptr.X = Pl.X;
                        ptr.Y = Pl.Y;
                        ct1 = 2;
                        Pl.gotgoal = 1;
                        Pl.hr = 0;
                        break;
                    }

                    Pl = Pl.right;
                }
                if (ct1 == 2)
                {

                    ptr.img = new Bitmap("coin.jpg");
                    ptr.W = 50;
                    ptr.H = 50;
                    ptr.img.MakeTransparent(ptr.img.GetPixel(0, 0));

                    Lgoal.Add(ptr);
                    ct1++;
                }
                else if (ct1 == 1)
                {
                    MessageBox.Show("plz click on the block itself");

                }

            }
            DrawScene(g);
        }

        private void Program_Load(object sender, EventArgs e)
        {
            L = new Clist();
            CNode check = new CNode();
            CNode C = new CNode();
            CNode check1 = new CNode();
            Random Random1 = new Random();
            Random Random = new Random();
            FirstRand = Random.Next(1, 60);
            Random Random2 = new Random();
            Random Random3 = new Random();

            for (int k = 0; k < 170; k++)
            {

                costr = Random.Next(1, 20);
                hrr = Random.Next(1, 10);
                CNode ptr = new CNode();
                ptr.X = pp1;
                ptr.Y = pp2;
                ptr.W = 30;
                ptr.H = 35;
                ptr.right = null;
                ptr.cost = costr;
                ptr.hr = hrr;
                pp1 += 35;
                ptr.id = ct;

                L.Attach(ptr);

                if (pp1 > 1070)
                {
                    pp1 = 505;
                    pp2 += 40;
                }
                ct++;
            }
            check = L.phead;
            C = L.phead;
            while (check.id != 153)
            {

                if (ct2 == 17)
                {
                    check1 = check;
                }
                while (C != null)
                {
                    if (check.id == C.id - 17)
                    {
                        check.down = C;
                        // Console.WriteLine(check.down.id);
                        break;

                    }

                    C = C.right;
                }
                check = check.right;
                ct2++;
            }
            C = L.phead;
            while (check1 != null)
            {

                while (C.id != 153)
                {
                    if (check1.id - 17 == C.id)
                    {
                        check1.up = C;
                        // Console.WriteLine(check1.up.id);
                        break;

                    }

                    C = C.right;
                }
                check1 = check1.right;

            }

            CNode pt = new CNode();

            for (int i = 0; i < FirstRand; i++)
            {
                pt = L.phead;

                SecondRand = Random1.Next(0, 170);
                while (pt.id != L.ptail.id)
                {
                    if (pt.id == SecondRand)
                    {
                        pt.iscolored = 1;
                    }
                    pt = pt.right;
                }

            }
            if (ct1 == 0)
            {
                MessageBox.Show("PLZ SELECT THE HERO'S POSITION");
            }

        }
        void ExpandBreadth()
        {
            Graphics g = this.CreateGraphics();
            CNode tree = new CNode();
            CNode tr = new CNode();
            int ctt = 0;

            while (tr.gotgoal != 1)
            {
                tree = L.phead;

                while (tree != null)
                {
                    if (tree.attachid < min)
                    {
                        tr = tree;
                        min = tree.attachid;

                    }


                    tree = tree.right;

                }


                //Console.WriteLine(tr.attachid);

                if (tr.left != null && tr.left.iscolored == 0 && tr.left.IsChecked == 0 && tr.left.gotgoal == 0)
                {
                    //CNode PP = new CNode();
                    //PP.X = Pr.X;

                    tr.left.IsChecked = 1;
                    tr.left.parentid = tr.id;
                    tr.left.attachid = at++;

                    //route.attach(Pr.left);
                }
                else if (tr.left != null && tr.left.gotgoal == 1)
                {
                    tr.left.parentid = tr.id;
                    tr = tr.left;
                    ctt++;
                    break;
                }

                if (tr.up != null && tr.up.iscolored == 0 && tr.up.IsChecked == 0 && tr.up.gotgoal == 0)
                {

                    tr.up.IsChecked = 1;
                    tr.up.parentid = tr.id;
                    tr.up.attachid = at++;

                    //route.Attach(Pr.up);
                }
                else if (tr.up != null && tr.up.gotgoal == 1)
                {
                    tr.up.parentid = tr.id;
                    tr = tr.up;
                    ctt++;
                    break;
                }

                if (tr.down != null && tr.down.iscolored == 0 && tr.down.IsChecked == 0 && tr.down.gotgoal == 0)
                {

                    tr.down.IsChecked = 1;
                    tr.down.parentid = tr.id;
                    tr.down.attachid = at++;

                    //route.Attach(Pr.down);
                }
                else if (tr.down != null && tr.down.gotgoal == 1)
                {
                    tr.down.parentid = tr.id;
                    tr = tr.down;
                    ctt++;
                    break;
                }
                if (tr.right != null && tr.right.iscolored == 0 && tr.right.IsChecked == 0 && tr.right.gotgoal == 0)
                {

                    tr.right.IsChecked = 1;
                    tr.right.parentid = tr.id;
                    tr.right.attachid = at++;
                    //Console.WriteLine(tr.right.parentid);
                    //route.Attach(Pr.right);
                }
                else if (tr.right != null && tr.right.gotgoal == 1)
                {
                    tr.right.parentid = tr.id;
                    tr = tr.right;

                    //ctt++;
                    break;
                }
                tr.attachid = 1000;
                min = 999999;
                DrawScene(g);

            }
            //Console.WriteLine(tr.id);
            //Console.WriteLine(tr.parentid);
            if (tr.gotgoal == 1)
            {
                // MessageBox.Show("yeeeees");
                while (tr.id != Pr.id)
                {
                    nm = L.phead;
                    while (tr.parentid != nm.id)
                    {

                        nm = nm.right;
                    }
                    tr = nm;
                    Croute x = new Croute();
                    x.X = nm.X;
                    x.Y = nm.Y;
                    route.Add(x);
                    tr.IsChecked = 3;
                    Console.WriteLine(tr.id);
                    Console.WriteLine(Pr.id);
                }


                int t = route.Count - 1;
                Croute k = new Croute();
                Hero h = new Hero();
                h = LHero[0];
                Console.WriteLine(t);
                //Console.WriteLine(Pr.id);
                for (int j = 0; j < route.Count; j++)
                {
                    for (int i = 0; i < route.Count; i++)
                    {
                        if (i == t)
                        {
                            k = route[t];
                            h.X = k.X;
                            h.Y = k.Y;
                        }
                        DrawScene(g);
                    }
                    t--;
                }
                DrawScene(g);
            }
        }
        void astar()
        {
            Graphics g = this.CreateGraphics();
            CNode tree = new CNode();
            CNode tr = new CNode();
            int ctt = 0;

            while (tr.gotgoal != 1)
            {
                tree = L.phead;

                while (tree != null)
                {
                    if (tree.IsChecked == 1)
                    {
                        if (tree.hr + tree.cost < min)
                        {


                            tr = tree;
                            min = tree.hr + tree.cost;
                            Console.WriteLine(tr.hr);

                        }

                    }

                    tree = tree.right;

                }
                Console.WriteLine(tr.hr);

                if (tr.left != null && tr.left.iscolored == 0 && tr.left.IsChecked == 0 && tr.left.gotgoal == 0)
                {
                    //CNode PP = new CNode();
                    //PP.X = Pr.X;
                    tr.left.greedytotal += tr.left.hr + tr.left.cost ;
                    tr.left.IsChecked = 1;
                    tr.left.parentid = tr.id;
                    tr.left.attachid = at++;

                    //route.attach(Pr.left);
                }
                else if (tr.left != null && tr.left.gotgoal == 1)
                {
                    tr.left.parentid = tr.id;
                    tr = tr.left;
                    ctt++;
                    break;
                }

                if (tr.up != null && tr.up.iscolored == 0 && tr.up.IsChecked == 0 && tr.up.gotgoal == 0)
                {
                    tr.up.greedytotal += tr.up.hr + tr.up.cost;
                    tr.up.IsChecked = 1;
                    tr.up.parentid = tr.id;
                    tr.up.attachid = at++;

                    //route.Attach(Pr.up);
                }
                else if (tr.up != null && tr.up.gotgoal == 1)
                {
                    tr.up.parentid = tr.id;
                    tr = tr.up;
                    ctt++;
                    break;
                }
                if (tr.down != null && tr.down.iscolored == 0 && tr.down.IsChecked == 0 && tr.down.gotgoal == 0)
                {
                    tr.down.greedytotal += tr.down.hr + tr.down.cost; ;
                    tr.down.IsChecked = 1;
                    tr.down.parentid = tr.id;
                    tr.down.attachid = at++;

                    //route.Attach(Pr.down);
                }
                else if (tr.down != null && tr.down.gotgoal == 1)
                {
                    tr.down.parentid = tr.id;
                    tr = tr.down;
                    ctt++;
                    break;
                }


                if (tr.right != null && tr.right.iscolored == 0 && tr.right.IsChecked == 0 && tr.right.gotgoal == 0)
                {
                    tr.right.greedytotal += tr.right.hr + tr.right.cost;
                    tr.right.IsChecked = 1;
                    tr.right.parentid = tr.id;
                    tr.right.attachid = at++;
                    //Console.WriteLine(tr.right.parentid);
                    //route.Attach(Pr.right);
                }
                else if (tr.right != null && tr.right.gotgoal == 1)
                {
                    tr.right.parentid = tr.id;
                    tr = tr.right;

                    //ctt++;
                    break;
                }
                //Console.WriteLine(tr.attachid);



                tr.hr = 100;
                tr.cost = 100;
                min = 999999;
                DrawScene(g);

            }


            //Console.WriteLine(tr.id);
            //Console.WriteLine(tr.parentid);
            if (tr.gotgoal == 1)
            {
                // MessageBox.Show("yeeeees");
                while (tr.id != Pr.id)
                {
                    nm = L.phead;
                    while (tr.parentid != nm.id)
                    {

                        nm = nm.right;
                    }
                    tr = nm;
                    Croute x = new Croute();
                    x.X = nm.X;
                    x.Y = nm.Y;
                    route.Add(x);
                    tr.IsChecked = 3;
                    Console.WriteLine(tr.id);
                    Console.WriteLine(Pr.id);
                }


                int t = route.Count - 1;
                Croute k = new Croute();
                Hero h = new Hero();
                h = LHero[0];
                Console.WriteLine(t);
                //Console.WriteLine(Pr.id);
                for (int j = 0; j < route.Count; j++)
                {
                    for (int i = 0; i < route.Count; i++)
                    {
                        if (i == t)
                        {
                            k = route[t];
                            h.X = k.X;
                            h.Y = k.Y;
                        }
                        DrawScene(g);
                    }
                    t--;
                }
                DrawScene(g);
            }
        }
        void greedy()
        {
            Graphics g = this.CreateGraphics();
            CNode tree = new CNode();
            CNode tr = new CNode();
            int ctt = 0;

            while (tr.gotgoal != 1)
            {
                tree = L.phead;

                while (tree != null)
                {
                    if (tree.IsChecked == 1 )
                    {
                        if (tree.hr < min)
                        {
                           
                             
                                tr = tree;
                                min = tree.hr;
                                Console.WriteLine(tr.hr);
                           
                        }

                    }

                    tree = tree.right;

                }
                Console.WriteLine(tr.hr);
               
                if (tr.left != null && tr.left.iscolored == 0 && tr.left.IsChecked == 0 && tr.left.gotgoal == 0)
                {
                    //CNode PP = new CNode();
                    //PP.X = Pr.X;
                    tr.left.greedytotal += tr.left.hr;
                    tr.left.IsChecked = 1;
                    tr.left.parentid = tr.id;
                    tr.left.attachid = at++;

                    //route.attach(Pr.left);
                }
                else if (tr.left != null && tr.left.gotgoal == 1)
                {
                    tr.left.parentid = tr.id;
                    tr = tr.left;
                    ctt++;
                    break;
                }

                if (tr.up != null && tr.up.iscolored == 0 && tr.up.IsChecked == 0 && tr.up.gotgoal == 0)
                {
                    tr.up.greedytotal += tr.up.hr;
                    tr.up.IsChecked = 1;
                    tr.up.parentid = tr.id;
                    tr.up.attachid = at++;

                    //route.Attach(Pr.up);
                }
                else if (tr.up != null && tr.up.gotgoal == 1)
                {
                    tr.up.parentid = tr.id;
                    tr = tr.up;
                    ctt++;
                    break;
                }
                if (tr.down != null && tr.down.iscolored == 0 && tr.down.IsChecked == 0 && tr.down.gotgoal == 0)
                {
                    tr.down.greedytotal += tr.down.hr;
                    tr.down.IsChecked = 1;
                    tr.down.parentid = tr.id;
                    tr.down.attachid = at++;

                    //route.Attach(Pr.down);
                }
                else if (tr.down != null && tr.down.gotgoal == 1)
                {
                    tr.down.parentid = tr.id;
                    tr = tr.down;
                    ctt++;
                    break;
                }


                if (tr.right != null && tr.right.iscolored == 0 && tr.right.IsChecked == 0 && tr.right.gotgoal == 0)
                {
                    tr.right.greedytotal += tr.right.hr;
                    tr.right.IsChecked = 1;
                    tr.right.parentid = tr.id;
                    tr.right.attachid = at++;
                    //Console.WriteLine(tr.right.parentid);
                    //route.Attach(Pr.right);
                }
                else if (tr.right != null && tr.right.gotgoal == 1)
                {
                    tr.right.parentid = tr.id;
                    tr = tr.right;

                    //ctt++;
                    break;
                }
                //Console.WriteLine(tr.attachid);



                tr.hr = 100;
                min = 999999;
                DrawScene(g);
                
            }

            
            //Console.WriteLine(tr.id);
            //Console.WriteLine(tr.parentid);
            if (tr.gotgoal == 1)
            {
                // MessageBox.Show("yeeeees");
                while (tr.id != Pr.id)
                {
                    nm = L.phead;
                    while (tr.parentid != nm.id)
                    {

                        nm = nm.right;
                    }
                    tr = nm;
                    Croute x = new Croute();
                    x.X = nm.X;
                    x.Y = nm.Y;
                    route.Add(x);
                    tr.IsChecked = 3;
                    Console.WriteLine(tr.id);
                    Console.WriteLine(Pr.id);
                }


                int t = route.Count - 1;
                Croute k = new Croute();
                Hero h = new Hero();
                h = LHero[0];
                Console.WriteLine(t);
                //Console.WriteLine(Pr.id);
                for (int j = 0; j < route.Count; j++)
                {
                    for (int i = 0; i < route.Count; i++)
                    {
                        if (i == t)
                        {
                            k = route[t];
                            h.X = k.X;
                            h.Y = k.Y;
                        }
                        DrawScene(g);
                    }
                    t--;
                }
                DrawScene(g);
            }
        }
        public void UC()
        {

            Graphics g = this.CreateGraphics();
            CNode tree = new CNode();
            CNode tr = new CNode();
            int ctt = 0;

            while (tr.gotgoal != 1)
            {
                tree = L.phead;

                while (tree != null)
                {
                    if (tree.IsChecked == 1)
                    {
                        if (tree.cost < min)
                        {


                            tr = tree;
                            min = tree.cost;
                            Console.WriteLine(tr.hr);

                        }

                    }

                    tree = tree.right;

                }
                Console.WriteLine(tr.hr);

                if (tr.left != null && tr.left.iscolored == 0 && tr.left.IsChecked == 0 && tr.left.gotgoal == 0)
                {
                    //CNode PP = new CNode();
                    //PP.X = Pr.X;
                    tr.left.greedytotal += tr.left.cost;
                    tr.left.IsChecked = 1;
                    tr.left.parentid = tr.id;
                    tr.left.attachid = at++;

                    //route.attach(Pr.left);
                }
                else if (tr.left != null && tr.left.gotgoal == 1)
                {
                    tr.left.parentid = tr.id;
                    tr = tr.left;
                    ctt++;
                    break;
                }

                if (tr.up != null && tr.up.iscolored == 0 && tr.up.IsChecked == 0 && tr.up.gotgoal == 0)
                {
                    tr.up.greedytotal += tr.up.cost;
                    tr.up.IsChecked = 1;
                    tr.up.parentid = tr.id;
                    tr.up.attachid = at++;

                    //route.Attach(Pr.up);
                }
                else if (tr.up != null && tr.up.gotgoal == 1)
                {
                    tr.up.parentid = tr.id;
                    tr = tr.up;
                    ctt++;
                    break;
                }
                if (tr.down != null && tr.down.iscolored == 0 && tr.down.IsChecked == 0 && tr.down.gotgoal == 0)
                {
                    tr.down.greedytotal += tr.down.cost;
                    tr.down.IsChecked = 1;
                    tr.down.parentid = tr.id;
                    tr.down.attachid = at++;

                    //route.Attach(Pr.down);
                }
                else if (tr.down != null && tr.down.gotgoal == 1)
                {
                    tr.down.parentid = tr.id;
                    tr = tr.down;
                    ctt++;
                    break;
                }


                if (tr.right != null && tr.right.iscolored == 0 && tr.right.IsChecked == 0 && tr.right.gotgoal == 0)
                {
                    tr.right.greedytotal += tr.right.cost;
                    tr.right.IsChecked = 1;
                    tr.right.parentid = tr.id;
                    tr.right.attachid = at++;
                    //Console.WriteLine(tr.right.parentid);
                    //route.Attach(Pr.right);
                }
                else if (tr.right != null && tr.right.gotgoal == 1)
                {
                    tr.right.parentid = tr.id;
                    tr = tr.right;

                    //ctt++;
                    break;
                }
                //Console.WriteLine(tr.attachid);



                tr.cost = 100;
                min = 999999;
                DrawScene(g);

            }


            //Console.WriteLine(tr.id);
            //Console.WriteLine(tr.parentid);
            if (tr.gotgoal == 1)
            {
                // MessageBox.Show("yeeeees");
                while (tr.id != Pr.id)
                {
                    nm = L.phead;
                    while (tr.parentid != nm.id)
                    {

                        nm = nm.right;
                    }
                    tr = nm;
                    Croute x = new Croute();
                    x.X = nm.X;
                    x.Y = nm.Y;
                    route.Add(x);
                    tr.IsChecked = 3;
                    Console.WriteLine(tr.id);
                    Console.WriteLine(Pr.id);
                }


                int t = route.Count - 1;
                Croute k = new Croute();
                Hero h = new Hero();
                h = LHero[0];
                Console.WriteLine(t);
                //Console.WriteLine(Pr.id);
                for (int j = 0; j < route.Count; j++)
                {
                    for (int i = 0; i < route.Count; i++)
                    {
                        if (i == t)
                        {
                            k = route[t];
                            h.X = k.X;
                            h.Y = k.Y;
                        }
                        DrawScene(g);
                    }
                    t--;
                }
                DrawScene(g);
            }


        }
        void expanddepth()
        {
            Graphics g = this.CreateGraphics();
            CNode tree = new CNode();
            CNode tr = new CNode();
            int ctt = 0;

            while (tr.gotgoal != 1)
            {
                tree = L.phead;

                while (tree != null)
                {
                    if (tree.attachidd > max)
                    {
                        tr = tree;
                        max = tree.attachidd;


                    }


                    tree = tree.right;

                }
                Console.WriteLine(tr.attachidd);

                if (tr.left != null && tr.left.iscolored == 0 && tr.left.IsChecked == 0 && tr.left.gotgoal == 0)
                {
                    //CNode PP = new CNode();
                    //PP.X = Pr.X;

                    tr.left.IsChecked = 1;
                    tr.left.parentid = tr.id;
                    tr.left.attachidd = at++;

                    //route.attach(Pr.left);
                }
                else if (tr.left != null && tr.left.gotgoal == 1)
                {
                    tr.left.parentid = tr.id;
                    tr = tr.left;
                    ctt++;
                    break;
                }

                if (tr.up != null && tr.up.iscolored == 0 && tr.up.IsChecked == 0 && tr.up.gotgoal == 0)
                {

                    tr.up.IsChecked = 1;
                    tr.up.parentid = tr.id;
                    tr.up.attachidd = at++;

                    //route.Attach(Pr.up);
                }
                else if (tr.up != null && tr.up.gotgoal == 1)
                {
                    tr.up.parentid = tr.id;
                    tr = tr.up;
                    ctt++;
                    break;
                }
                if (tr.down != null && tr.down.iscolored == 0 && tr.down.IsChecked == 0 && tr.down.gotgoal == 0)
                {

                    tr.down.IsChecked = 1;
                    tr.down.parentid = tr.id;
                    tr.down.attachidd = at++;

                    //route.Attach(Pr.down);
                }
                else if (tr.down != null && tr.down.gotgoal == 1)
                {
                    tr.down.parentid = tr.id;
                    tr = tr.down;
                    ctt++;
                    break;
                }


                if (tr.right != null && tr.right.iscolored == 0 && tr.right.IsChecked == 0 && tr.right.gotgoal == 0)
                {

                    tr.right.IsChecked = 1;
                    tr.right.parentid = tr.id;
                    tr.right.attachidd = at++;
                    //Console.WriteLine(tr.right.parentid);
                    //route.Attach(Pr.right);
                }
                else if (tr.right != null && tr.right.gotgoal == 1)
                {
                    tr.right.parentid = tr.id;
                    tr = tr.right;

                    //ctt++;
                    break;
                }
                //Console.WriteLine(tr.attachid);



                tr.attachidd = -1000;
                max = -999999;
                DrawScene(g);

            }
            //Console.WriteLine(tr.id);
            //Console.WriteLine(tr.parentid);
            if (tr.gotgoal == 1)
            {
                // MessageBox.Show("yeeeees");
                while (tr.id != Pr.id)
                {
                    nm = L.phead;
                    while (tr.parentid != nm.id)
                    {

                        nm = nm.right;
                    }
                    tr = nm;
                    Croute x = new Croute();
                    x.X = nm.X;
                    x.Y = nm.Y;
                    route.Add(x);
                    tr.IsChecked = 3;
                    Console.WriteLine(tr.id);
                    Console.WriteLine(Pr.id);
                }


                int t = route.Count - 1;
                Croute k = new Croute();
                Hero h = new Hero();
                h = LHero[0];
                Console.WriteLine(t);
                //Console.WriteLine(Pr.id);
                for (int j = 0; j < route.Count; j++)
                {
                    for (int i = 0; i < route.Count; i++)
                    {
                        if (i == t)
                        {
                            k = route[t];
                            h.X = k.X;
                            h.Y = k.Y;
                        }
                        DrawScene(g);
                    }
                    t--;
                }
                DrawScene(g);
            }
        }
        private void Program_Paint(object sender, PaintEventArgs e)
        {
            DrawScene(CreateGraphics());
        }

        private void Program_KeyDown(object sender, KeyEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            if (e.KeyCode == Keys.A)
            {
                Clist route = new Clist();
                Hero hero = new Hero();
                hero = LHero[0];
                Goal goal = new Goal();
                goal = Lgoal[0];

                Pr = L.phead;



                while (Pr != null)
                {
                    if (Pr.gothero == 1)
                    {

                        if (Pr.left != null && Pr.left.iscolored == 0 && Pr.left.IsChecked == 0 && Pr.left.gotgoal == 0)
                        {
                            //CNode PP = new CNode();
                            //PP.X = Pr.X;
                            Pr.left.greedytotal += Pr.left.cost + Pr.up.hr;
                            Pr.left.IsChecked = 1;
                            Pr.left.parentid = Pr.id;
                            Pr.left.attachid = at++;
                            // Console.WriteLine(Pr.left.attachid);
                            //route.attach(Pr.left);
                        }

                        if (Pr.up != null && Pr.up.iscolored == 0 && Pr.up.IsChecked == 0 && Pr.up.gotgoal == 0)
                        {
                            Pr.up.greedytotal += Pr.up.cost + Pr.up.hr;
                            Pr.up.IsChecked = 1;
                            Pr.up.parentid = Pr.id;
                            Pr.up.attachid = at++;
                            //Console.WriteLine(Pr.up.attachid);
                            //route.Attach(Pr.up);
                        }

                        if (Pr.down != null && Pr.down.iscolored == 0 && Pr.down.IsChecked == 0 && Pr.down.gotgoal == 0)
                        {
                            Pr.down.greedytotal += Pr.down.cost + Pr.down.hr;
                            Pr.down.IsChecked = 1;
                            Pr.down.parentid = Pr.id;
                            Pr.down.attachid = at++;
                            //Console.WriteLine(Pr.down.attachid);
                            //route.Attach(Pr.down);
                        }
                        if (Pr.right != null && Pr.right.iscolored == 0 && Pr.right.IsChecked == 0 && Pr.right.gotgoal == 0)
                        {
                            Pr.right.greedytotal += Pr.right.cost + Pr.right.hr;
                            Pr.right.IsChecked = 1;
                            Pr.right.parentid = Pr.id;
                            Pr.right.attachid = at++;
                            //Console.WriteLine(Pr.right.attachid);
                            //route.Attach(Pr.right);
                        }

                        break;

                    }
                    Pr = Pr.right;

                }

                DrawScene(g);
                astar();
            }
            if (e.KeyCode == Keys.U)
            {
                Clist route = new Clist();
                Hero hero = new Hero();
                hero = LHero[0];
                Goal goal = new Goal();
                goal = Lgoal[0];

                Pr = L.phead;



                while (Pr != null)
                {
                    if (Pr.gothero == 1)
                    {

                        if (Pr.left != null && Pr.left.iscolored == 0 && Pr.left.IsChecked == 0 && Pr.left.gotgoal == 0)
                        {
                            //CNode PP = new CNode();
                            //PP.X = Pr.X;
                            Pr.left.greedytotal += Pr.left.cost;
                            Pr.left.IsChecked = 1;
                            Pr.left.parentid = Pr.id;
                            Pr.left.attachid = at++;
                            // Console.WriteLine(Pr.left.attachid);
                            //route.attach(Pr.left);
                        }

                        if (Pr.up != null && Pr.up.iscolored == 0 && Pr.up.IsChecked == 0 && Pr.up.gotgoal == 0)
                        {
                            Pr.up.greedytotal += Pr.up.cost;
                            Pr.up.IsChecked = 1;
                            Pr.up.parentid = Pr.id;
                            Pr.up.attachid = at++;
                            //Console.WriteLine(Pr.up.attachid);
                            //route.Attach(Pr.up);
                        }

                        if (Pr.down != null && Pr.down.iscolored == 0 && Pr.down.IsChecked == 0 && Pr.down.gotgoal == 0)
                        {
                            Pr.down.greedytotal += Pr.down.cost;
                            Pr.down.IsChecked = 1;
                            Pr.down.parentid = Pr.id;
                            Pr.down.attachid = at++;
                            //Console.WriteLine(Pr.down.attachid);
                            //route.Attach(Pr.down);
                        }
                        if (Pr.right != null && Pr.right.iscolored == 0 && Pr.right.IsChecked == 0 && Pr.right.gotgoal == 0)
                        {
                            Pr.right.greedytotal += Pr.right.cost;
                            Pr.right.IsChecked = 1;
                            Pr.right.parentid = Pr.id;
                            Pr.right.attachid = at++;
                            //Console.WriteLine(Pr.right.attachid);
                            //route.Attach(Pr.right);
                        }

                        break;

                    }
                    Pr = Pr.right;

                }

                DrawScene(g);
                UC();
            }
            if (e.KeyCode == Keys.G)
            {
                Clist route = new Clist();
                Hero hero = new Hero();
                hero = LHero[0];
                Goal goal = new Goal();
                goal = Lgoal[0];

                Pr = L.phead;



                while (Pr != null)
                {
                    if (Pr.gothero == 1)
                    {

                        if (Pr.left != null && Pr.left.iscolored == 0 && Pr.left.IsChecked == 0 && Pr.left.gotgoal == 0)
                        {
                            //CNode PP = new CNode();
                            //PP.X = Pr.X;
                            Pr.left.greedytotal += Pr.left.hr;
                            Pr.left.IsChecked = 1;
                            Pr.left.parentid = Pr.id;
                            Pr.left.attachid = at++;
                            // Console.WriteLine(Pr.left.attachid);
                            //route.attach(Pr.left);
                        }

                        if (Pr.up != null && Pr.up.iscolored == 0 && Pr.up.IsChecked == 0 && Pr.up.gotgoal == 0)
                        {

                            Pr.up.IsChecked = 1;
                            Pr.up.greedytotal += Pr.up.hr;
                            Pr.up.parentid = Pr.id;
                            Pr.up.attachid = at++;
                            //Console.WriteLine(Pr.up.attachid);
                            //route.Attach(Pr.up);
                        }

                        if (Pr.down != null && Pr.down.iscolored == 0 && Pr.down.IsChecked == 0 && Pr.down.gotgoal == 0)
                        {
                            Pr.down.greedytotal += Pr.down.hr;
                            Pr.down.IsChecked = 1;
                            Pr.down.parentid = Pr.id;
                            Pr.down.attachid = at++;
                            //Console.WriteLine(Pr.down.attachid);
                            //route.Attach(Pr.down);
                        }
                        if (Pr.right != null && Pr.right.iscolored == 0 && Pr.right.IsChecked == 0 && Pr.right.gotgoal == 0)
                        {
                            Pr.right.greedytotal += Pr.right.hr;
                            Pr.right.IsChecked = 1;
                            Pr.right.parentid = Pr.id;
                            Pr.right.attachid = at++;
                            //Console.WriteLine(Pr.right.attachid);
                            //route.Attach(Pr.right);
                        }

                        break;

                    }
                    Pr = Pr.right;

                }

               
                greedy();
                DrawScene(g);
            }
            if (e.KeyCode == Keys.D)
            {
                Clist route = new Clist();
                Hero hero = new Hero();
                hero = LHero[0];
                Goal goal = new Goal();
                goal = Lgoal[0];

                Pr = L.phead;



                while (Pr != null)
                {
                    if (Pr.gothero == 1)
                    {

                        if (Pr.left != null && Pr.left.iscolored == 0 && Pr.left.IsChecked == 0 && Pr.left.gotgoal == 0)
                        {
                            //CNode PP = new CNode();
                            //PP.X = Pr.X;

                            Pr.left.IsChecked = 1;
                            Pr.left.parentid = Pr.id;
                            Pr.left.attachidd = at++;
                            // Console.WriteLine(Pr.left.attachid);
                            //route.attach(Pr.left);
                        }

                        if (Pr.up != null && Pr.up.iscolored == 0 && Pr.up.IsChecked == 0 && Pr.up.gotgoal == 0)
                        {

                            Pr.up.IsChecked = 1;
                            Pr.up.parentid = Pr.id;
                            Pr.up.attachidd = at++;
                            //Console.WriteLine(Pr.up.attachid);
                            //route.Attach(Pr.up);
                        }

                        if (Pr.down != null && Pr.down.iscolored == 0 && Pr.down.IsChecked == 0 && Pr.down.gotgoal == 0)
                        {

                            Pr.down.IsChecked = 1;
                            Pr.down.parentid = Pr.id;
                            Pr.down.attachidd = at++;
                            //Console.WriteLine(Pr.down.attachid);
                            //route.Attach(Pr.down);
                        }
                        if (Pr.right != null && Pr.right.iscolored == 0 && Pr.right.IsChecked == 0 && Pr.right.gotgoal == 0)
                        {

                            Pr.right.IsChecked = 1;
                            Pr.right.parentid = Pr.id;
                            Pr.right.attachidd = at++;
                            //Console.WriteLine(Pr.right.attachid);
                            //route.Attach(Pr.right);
                        }

                        break;

                    }
                    Pr = Pr.right;

                }

                DrawScene(g);
                expanddepth();
                // MessageBox.Show("gotit");
            }

            if (e.KeyCode == Keys.B)
            {
                Clist route = new Clist();
                Hero hero = new Hero();
                hero = LHero[0];
                Goal goal = new Goal();
                goal = Lgoal[0];

                Pr = L.phead;



                while (Pr != null)
                {
                    if (Pr.gothero == 1)
                    {

                        if (Pr.left != null && Pr.left.iscolored == 0 && Pr.left.IsChecked == 0 && Pr.left.gotgoal == 0)
                        {
                            //CNode PP = new CNode();
                            //PP.X = Pr.X;

                            Pr.left.IsChecked = 1;
                            Pr.left.parentid = Pr.id;
                            Pr.left.attachid = at++;
                            // Console.WriteLine(Pr.left.attachid);
                            //route.attach(Pr.left);
                        }

                        if (Pr.up != null && Pr.up.iscolored == 0 && Pr.up.IsChecked == 0 && Pr.up.gotgoal == 0)
                        {

                            Pr.up.IsChecked = 1;
                            Pr.up.parentid = Pr.id;
                            Pr.up.attachid = at++;
                            //Console.WriteLine(Pr.up.attachid);
                            //route.Attach(Pr.up);
                        }

                        if (Pr.down != null && Pr.down.iscolored == 0 && Pr.down.IsChecked == 0 && Pr.down.gotgoal == 0)
                        {

                            Pr.down.IsChecked = 1;
                            Pr.down.parentid = Pr.id;
                            Pr.down.attachid = at++;
                            //Console.WriteLine(Pr.down.attachid);
                            //route.Attach(Pr.down);
                        }
                        if (Pr.right != null && Pr.right.iscolored == 0 && Pr.right.IsChecked == 0 && Pr.right.gotgoal == 0)
                        {

                            Pr.right.IsChecked = 1;
                            Pr.right.parentid = Pr.id;
                            Pr.right.attachid = at++;
                            //Console.WriteLine(Pr.right.attachid);
                            //route.Attach(Pr.right);
                        }

                        break;

                    }
                    Pr = Pr.right;

                }

                DrawScene(g);
                ExpandBreadth();
                // MessageBox.Show("gotit");
            }

            DrawScene(g);
        }

        void DrawScene(Graphics g)
        {
            g.Clear(Color.Black);
            g.FillRectangle(Brushes.Brown, 500, 200, 600, 400);
            //MessageBox.Show("done");
            //for (int i = 0; i < l1.Count; i++)
            //{
            //    g.FillRectangle(Brushes.Lavender, l1[i].X, l1[i].Y, l1[i].W, l1[i].H);
            //}

            for (int i = 0; i < Lgoal.Count; i++)
            {
                g.DrawImage(Lgoal[i].img, Lgoal[i].X, Lgoal[i].Y, width: 30, height: 30);
            }
            CNode p = new CNode();
            p = L.phead;
            while (p != null)
            {
                if (p.iscolored == 1)
                {
                    g.FillRectangle(Brushes.Black, p.X, p.Y, p.W, p.W);
                }
                if (p.IsChecked == 1 && p.iscolored == 0)
                {
                    g.FillRectangle(Brushes.Cyan, p.X, p.Y, p.W, p.W);
                }
                if (p.IsChecked == 3)
                {
                    g.FillRectangle(Brushes.NavajoWhite, p.X, p.Y, p.W, p.W);
                }
                p = p.right;

            }
            for (int i = 0; i < LHero.Count; i++)
            {
                g.DrawImage(LHero[i].img, LHero[i].X, LHero[i].Y, width: 30, height: 35);
            }
            //for (int i = 0; i < list.Count; i++)
            //{

            //    SolidBrush b = new SolidBrush(list[i].clr);
            //    g.FillEllipse(b,
            //                    list[i].X, list[i].Y,
            //                    list[i].W, list[i].H);
            //    g.DrawEllipse(Pens.Black,
            //                    list[i].X, list[i].Y,
            //                    list[i].W, list[i].H);


            //}

        }


        static void Main()
        {
            Program shosho = new Program();
            Application.Run(shosho);
        }
    }
}