using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MicroImageAnalyzer
{
    public class Spot
    {
        private int[] Count473;
        private int[] Count561;
        private int[] IntDen;

        public Spot()
		{
		}

        public int[] _getCount473()
        {
            return this.Count473;
        }

        public int[] _getCount561()
        {
            return this.Count561;
        }

        public int[] _getIntDen()
        {
            return this.IntDen;
        }

        public void _setCount473(int[] _count473)
        {
            this.Count473 = _count473;
        }

        public void _setCount561(int[] _count561)
        {
            this.Count561 = _count561;
        }

        public void _setIntDen(int[] _intDen)
        {
            this.IntDen = _intDen;
        }
    }
}
