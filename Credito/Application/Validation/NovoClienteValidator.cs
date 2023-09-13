using Application.DTO.Cliente;
using Application.Util;
using FluentValidation;

namespace Application.Validation
{
    public class NovoClienteValidator : AbstractValidator<NovoClienteRequest>
    {
        public NovoClienteValidator()
        {
            RuleFor(x => x.Nome)
                .MaximumLength(250).WithMessage("Nome não pode ser maior que 250 caracteres");

            RuleFor(x => x.UF)
                .Length(2).WithMessage("UF pode conter apenas 2 caracteres");

            RuleFor(x => x.DDD)
                .Length(2).WithMessage("DDD pode conter apenas 2 digitos");

            RuleFor(x => x.Ceular)
                .Must(ValidarCelularLenghtMaximo).WithMessage("Celular inválido. Contém mais que 9 digitos");

            RuleFor(x => x.CPF)
                .Must(ValidarCPFLenghtMaximo).WithMessage("CPF inválido");
        }

        private bool ValidarCelularLenghtMaximo(string celular)
        {
            celular = RegexUtil.SomenteNumero(celular);
            return celular.Length < 10;
        }

        private bool ValidarCPFLenghtMaximo(string cpf)
        {
            cpf = RegexUtil.SomenteNumero(cpf);
            return cpf.Length == 11;
        }
    }
}
