namespace TaskTracker.Helpers
{
    public class DtoNullHelper
    {
        public static bool dtoVazioOuNulo(object dto)
        {
            if (dto == null) return true;
            
            var propriedades = dto.GetType().GetProperties();
            foreach ( var prop in propriedades )
            {
                var valor = prop.GetValue(dto);

                if (valor is string str && !string.IsNullOrWhiteSpace(str))
                    return false;

                if (valor != null && !valor.Equals(GetDefault(prop.PropertyType)))
                    return false;
            }

            return true;
        }

        private static object GetDefault(Type tipo)
        {
            return tipo.IsValueType ? Activator.CreateInstance(tipo) : null;
        }

    }
}
