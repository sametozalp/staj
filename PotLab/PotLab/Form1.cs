using System;
using System.Windows.Forms;

namespace PotLab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double[] Buffer1 = new double[1000];
            double[] Buffer2 = new double[1000];
            for (int i = 0; i < 1000; i++)
            {
                Buffer1[i] = m_RandomGen.NextDouble() * 40000 -
               20000;
                Buffer2[i] = (m_Counter % 120) * 300 - 18000;
                m_Counter++;
            }
            scope1.Channels[0].Data.SetYData(Buffer1);
            scope1.Channels[1].Data.SetYData(Buffer2);

        }
        private Random m_RandomGen = new Random(123);
        private int m_Counter = 0;

        private void timer2_Tick(object sender, EventArgs e)
        {
            double[] Buffer = new double[1000];
            for (int i = 0; i < 1000; i++)
                Buffer[i] = m_RandomGenr.NextDouble() * 40000 - 20000;
            waterfall1.Data.AddData(Buffer);
        }
        private Random m_RandomGenr = new Random(123);
    }
}
