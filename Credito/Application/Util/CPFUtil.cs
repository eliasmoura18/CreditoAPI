using System.Text.RegularExpressions;

namespace Application.Util
{
    public static class CPFUtil
    {
        public static bool isValidoCPFVazio(string cpf)
        {
            cpf = RegexUtil.SomenteNumero(cpf);

            return !string.IsNullOrEmpty(cpf);
        }
    }
}
