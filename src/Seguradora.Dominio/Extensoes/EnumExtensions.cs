using System.ComponentModel;
using System.Reflection;

namespace Seguradora.Dominio.Extensoes
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Retorna a descrição do atributo "DescriptionString" de um enumerador.
        /// </summary>
        public static string GetDescricao<T>(this T @enum) where T : struct
        {
            FieldInfo info = @enum.GetType().GetField(@enum.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])info.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes?[0].Description ?? @enum.ToString();
        }
    }
}