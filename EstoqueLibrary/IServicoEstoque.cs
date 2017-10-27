using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueLibrary
{
    [ServiceContract(Namespace = "http://projetoavaliativo.dm113/01", Name = "IServicoEstoque")]
    public interface IServicoEstoque
    {
        [OperationContract]
        List<string> ListarProdutos();

        [OperationContract]
        bool incluirProduto(Produto produto);

        [OperationContract]
        bool removerProduto(string numeroProduto);

        [OperationContract]
        int consultarEstoque(string numeroProduto);

        [OperationContract]
        bool adicionarEstoque(string numeroProduto, int quantidade);

        [OperationContract]
        bool removerEstoque(string numeroProduto, int quantidade);

        [OperationContract]
        Produto verProduto(string numeroProduto);
    }

    [ServiceContract(Namespace = "http://projetoavaliativo.dm113/02", Name = "IServicoEstoqueV2")]
    public interface IServicoEstoqueV2
    {
        [OperationContract/*(ProtectionLevel = ProtectionLevel.Sign)*/]
        bool adicionarEstoque(string numeroProduto, int quantidade);

        [OperationContract/*(ProtectionLevel = ProtectionLevel.Sign)*/]
        bool removerEstoque(string numeroProduto, int quantidade);

        [OperationContract/*(ProtectionLevel = ProtectionLevel.Sign)*/]
        int consultarEstoque(string numeroProduto);
    }

    [DataContract]
    public class Produto
    {
        [DataMember]
        public string NumeroProduto { get; set; }
        [DataMember]
        public string NomeProduto { get; set; }
        [DataMember]
        public string DescricaoProduto { get; set; }
        [DataMember]
        public int EstoqueProduto { get; set; }
    }
}
