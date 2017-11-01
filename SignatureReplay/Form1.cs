using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace SignatureReplay
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnReplay_Click(object sender, EventArgs e)
        {
            var list = new List<ManagedIsoPoint>();

            var rnd = new Random();
            var dt = DateTime.Now;

            if (cbJson.Checked && !string.IsNullOrEmpty(tbSignatureB64.Text))
            {
                list = JsonConvert.DeserializeObject<List<ManagedIsoPoint>>(tbSignatureB64.Text);
            }
            else if (!cbJson.Checked && !string.IsNullOrEmpty(tbSignatureB64.Text))
            {
                list = Converter.StringToObject<List<ManagedIsoPoint>>(tbSignatureB64.Text);
            }
            else
            {
                for (int i = 0; i < 100; ++i)
                {
                    dt = dt.AddTicks(rnd.Next(1000));
                    list.Add(new ManagedIsoPoint { x = rnd.Next(600), y = rnd.Next(400), pressure = rnd.Next(1, 255), time = dt.Ticks });
                    //Thread.Sleep(rnd.Next(3000));
                }
            }

            var minX = list.Min(q => q.x);
            var minY = list.Min(q => q.y);
            var maxP = list.Max(q => q.pressure);
            var minP = list.Min(q => q.pressure);

            foreach (var a in list)
            {
                a.x -= minX;
                a.y -= minY;

                a.x /= 10;
                a.y /= 10;

                if (a.pressure == 0)
                    a.pressure = 1;
            }

            if (cbDev.Checked)
            {
                var maxDist = 0d;

                for (var i = 0; i < list.Count; ++i)
                {
                    for (var j = 1; j < list.Count; ++j)
                    {
                        if (i != j)
                        {
                            var dst = Utils.GetDistance((float)list[i].x,
                                (float)list[i].y,
                                (float)list[j].x,
                                (float)list[j].y);
                            if (dst > maxDist)
                                maxDist = dst;
                        }
                    }
                }

                var maxSpeed = list[list.Count - 1].time - list[0].time;

                for (var i = 1; i < list.Count; ++i)
                {
                    var dist = Utils.GetDistance((float)list[i - 1].x,
                        (float)list[i - 1].y,
                        (float)list[i].x,
                        (float)list[i].y);

                    var speed = maxSpeed / (list[i].time - list[i - 1].time);
                    //list[i].pressure = (int)((maxSpeed - speed) * nudThickness.Value);
                    list[i].pressure = (int)(maxDist * 200 / dist);
                    //list[i].time += 100 * i;
                }

                tbSignatureB64.Text = Converter.ObjectToString(list);
            }

            var rf = new ReplayForm(list, (int)nudThickness.Value, cbDots.Checked);
            rf.Show();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbSignatureB64.Text = "";
        }
    }
}
