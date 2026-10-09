using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace XulambsFoods
{
    public class PedidoLocal : Pedido
    {
        private const double PctServico = 0.10;

        private double TaxaServico()
        {
            return ValorPizzas() * (1.0 + PctServico);
        }

        public override double PrecoAPagar()
        {            
            return ValorPizzas() * (1.0 + PctServico);
        }



        protected override string RodapePedido()
        {
            StringBuilder relat = new StringBuilder();
            relat.AppendLine($"TAXA DE SERVIÇO: {TaxaServico():C2}");
            relat.AppendLine($"\nTOTAL DO PEDIDO: {PrecoAPagar():C2}");
            return relat.ToString();
        }
    }
}
