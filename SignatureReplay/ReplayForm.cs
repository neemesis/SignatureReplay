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

namespace SignatureReplay
{
    public partial class ReplayForm : Form
    {
        public List<ManagedIsoPoint> _points { get; set; }
        public long _runningTime { get; set; }
        private int _current = 0;
        private int _maxPressure;
        private int _thickness;
        private Graphics gfx;
        private Pen pen = new Pen(Brushes.Black);
        private Brush brush = new SolidBrush(Color.Black);
        private long _totalTicks = 0;
        private Button _restart;
        private DateTime _dt;
        private bool _dots;

        public ReplayForm(List<ManagedIsoPoint> points, int thickness, bool dots)
        {
            InitializeComponent();
            Application.EnableVisualStyles();
            _points = points;
            _thickness = thickness;
            _dots = dots;

            this.Size = new Size((int) (Math.Ceiling(_points.Max(q => q.x)) + Math.Floor(_points.Min(q => q.x))) + 300, 
                (int) (Math.Ceiling(_points.Max(q => q.y)) + Math.Floor(_points.Min(q => q.y))) + 300);

            _runningTime = _points.Max(q => q.time) - _points.Min(q => q.time);
            _maxPressure = _points.Max(q => q.pressure);

            gfx = this.CreateGraphics();
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            this.DoubleBuffered = true;

            _restart = new Button {
                Width = 100,
                Height = 30,
                Text = "Restart",
                Visible = false
            };

            this.Controls.Add(_restart);

            _restart.Click += (o, e) =>
            {
                Play();
            };

            Play();
        }

        public void Play()
        {
            _current = 0;
            _totalTicks = 0;

            _restart.Visible = false;

            gfx.Clear(Color.White);

            Thread.Sleep(1000);
            _dt = DateTime.Now;
            mainTimer.Start();

        }

        public void Stop()
        {
            mainTimer.Stop();

            _restart.Visible = true;
        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            _totalTicks += mainTimer.Interval;
            //_totalTicks = DateTime.Now.Ticks - _dt.Ticks;

            var diff = _points[_current].time - _points[0].time;
            if (diff > _totalTicks)
                return;

            ++_current;
            if (_current >= _points.Count)
            {
                Stop();
                return;
            }

            var thick = _thickness * _points[_current].pressure / _maxPressure; ;

            //gfx.FillEllipse(brush, (float)_points[_current].x, (float)_points[_current].y, _points[_current].pressure / _maxPressure, _points[_current].pressure / _maxPressure);

            if (_dots)
            {
                gfx.FillEllipse(brush, (float)_points[_current].x, this.Size.Height - (float)_points[_current].y - 100, thick, thick);
            } else
            {
                pen.Width = thick;
                //gfx.DrawLine(pen,
                //    (float)_points[_current - 1].x,
                //    this.Size.Width - (float)_points[_current - 1].y,
                //    (float)_points[_current].x,
                //    this.Size.Width - (float)_points[_current].y);


                gfx.DrawLine(pen,
                    (float)_points[_current - 1].x,
                    this.Size.Height - (float)_points[_current - 1].y - 100,
                    (float)_points[_current].x,
                    this.Size.Height - (float)_points[_current].y - 100);
            }

            //if (Utils.GetDistance((float)_points[_current - 1].x,
            //    (float)_points[_current - 1].y,
            //    (float)_points[_current].x,
            //    (float)_points[_current].y) > 50)
            //    return;
        }

        
    }
}
