using System.ComponentModel;

namespace Marketplace.Enums
{
    public enum StatusPedido
    {
        [Description("A fazer")]
        AComprar = 1,
        [Description("Em andamento")]
        EmAndamento = 2,
        [Description("Concluido")]
        Concluido = 3,
    }
}
