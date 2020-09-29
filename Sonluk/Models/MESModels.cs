using Sonluk.UI.Model.BC;
using Sonluk.UI.Model.MES;

namespace Sonluk.Models
{
    public class MESModels
    {
        private SY_GC sY_GC;
        private BarCode barCode;

        public SY_GC SY_GC { get => sY_GC ?? new SY_GC(); set => sY_GC = value; }
        public BarCode BarCode { get => barCode ?? new BarCode(); set => barCode = value; }
    }
}