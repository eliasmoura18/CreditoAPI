namespace Application.BusinessRules
{
    public static class SolicitacaoCreditoRules
    {
        public static decimal valorMaximoImprestimo { get => 1000000; }
        public static decimal valorMinimoImprestimoPessoaJuridica { get => 15000; }
        public static int prazoMinimoVencimentoPrimeiraParcela { get => 15; }
        public static int prazoMaximoVencimentoPrimeiraParcela { get => 40; }
        public static int qtdeMinParcelas { get => 5; }
        public static int qtdeMaxParcelas { get => 72; }
    }
}
