using System;
using System.Text;
using System.Xml;


namespace XulambsFoods {    
    public class Pizza {

        /// <summary>
        /// Lembre-se:
        // ENTENDER O PROBLEMA!!!
        //Regra 0 -- não entre em pânico
        //Regra 1 -- não viaje
        /// </summary>
        /// 
        #region atributos
        int _maxIngredientes;
        double _precoBase;
        int _quantIngredientes;
        double _valorPorAdicional;
        string _descricao;
        #endregion

        #region construtores
        public Pizza() {
            _descricao = "Pizza";
            _maxIngredientes = 8;
            _precoBase = 29d;
            _quantIngredientes = 0;
            _valorPorAdicional = 5d;
        }


        public void Init(int adicionais)
        {
            _descricao = "Pizza";
            _maxIngredientes = 8;
            _precoBase = 29d;
            AdicionarIngredientes(adicionais);
            _valorPorAdicional = 5d;
        }

        public Pizza(int adicionais) 
        {
            Init(adicionais);
        }
        #endregion

        #region métodos privados
        private double ValorAdicionais() {
            return _quantIngredientes * _valorPorAdicional;
        }

        private void ModificarDescricao() {
            _descricao = $"Pizza com {_quantIngredientes} adicionais";
        }

        private bool PodeAdicionar(int quantos) {
            return (quantos >= 0 && 
                quantos + _quantIngredientes <= _maxIngredientes);
        }
        #endregion

        #region métodos públicos
        public double CalcularValorFinal() {
            return _precoBase + ValorAdicionais();
        }

        public int AdicionarIngredientes(int quantos) {
            if (PodeAdicionar(quantos)) {
                _quantIngredientes = _quantIngredientes + quantos;
                ModificarDescricao();
            }
            return _quantIngredientes;
        }

        public string GerarCupom() {
            StringBuilder nota = new StringBuilder("\tXulambs Pizza!!!\n");
            nota.AppendLine("----------------------------------");
            nota.AppendLine($"{_descricao}:\n");
            nota.AppendLine($"Preco inicial:\t{_precoBase:C2}");
            nota.AppendLine($"Adicionais:\t{ValorAdicionais():C2}\n");
            nota.AppendLine($"Total: {CalcularValorFinal():C2}");
            nota.Append("----------------------------------");

            return nota.ToString();
        }
        #endregion

    }
}