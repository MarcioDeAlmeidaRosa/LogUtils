using log4net.Config;
using Serializacao;
using System;
using System.Diagnostics;
using System.Text;

namespace LogUtils
{
    public class Logger
    {
        // Objeto para gerar os logs        
        protected static readonly log4net.ILog Log;

        // Construtor estático
        static Logger()
        {
            // Instanciação do componente de log
            Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            try
            {
                // Inicialização do componente de log
                var info = new System.IO.FileInfo(LoggerBridge.GetInstance().GetPath());
                XmlConfigurator.Configure(info);
            }
            catch
            {
                // O logger não pode lançar exceções.
                // Caso o appSetting ArquivoConfiguracaoLog4Net seja nulo ou seja um arquivo inexistente, uma exceção será lançada.
                // Esta exceção deverá ser abrandada.
            }
        }

        private static string GetLastMethod()
        {
            // Cria a stack trace da exceção
            var stack = new StackTrace();

            // Busca o anti-penúltimo frame no stack (o último é o método atual, o penúltimo um dos métodos da classe)
            var sframe = stack.GetFrame(2);

            // Retorna o nome qualificado do método (Classe + método)
            var frame = sframe.GetMethod().DeclaringType;
            return frame != null ? String.Format("{0}.{1}", frame.Name, sframe.GetMethod().Name) : String.Empty;
        }

        private static string ToString(Object o)
        {
            return o == null ? "nulo" : o.ToString();
        }

        private static string FormataXML(String entrada)
        {
            if (entrada == null)
                return entrada;

            return entrada.Replace("&lt;", "<").Replace("&gt;", ">");
        }

        #region [Log Info]
        public static void LogInfo(string mensagem)
        {
            try
            {
                if (Log.IsInfoEnabled)
                {
                    Log.Info(mensagem);
                }
            }
            catch
            { }
        }

        public static void LogInfo(string mensagem, object arg0)
        {
            try
            {
                if (Log.IsInfoEnabled)
                {
                    Log.Info(String.Format(mensagem, arg0));
                }
            }
            catch { }
        }

        public static void LogInfo(string mensagem, object arg0, object arg1)
        {
            try
            {
                if (Log.IsInfoEnabled)
                {
                    Log.Info(String.Format(mensagem, arg0, arg1));
                }
            }
            catch { }
        }

        public static void LogInfo(string mensagem, object arg0, object arg1, object arg2)
        {
            try
            {
                if (Log.IsInfoEnabled)
                {
                    Log.Info(String.Format(mensagem, arg0, arg1, arg2));
                }
            }
            catch { }
        }

        public static void LogInfo(string mensagem, object[] argumentos)
        {
            try
            {
                if (Log.IsInfoEnabled)
                {
                    Log.Info(String.Format(mensagem, argumentos));
                }
            }
            catch { }
        }

        public static void LogInfo<T>(T parametro) where T : class
        {
            try
            {
                if (Log.IsInfoEnabled)
                {
                    var xmlDoc = Serialize.SerializeMe(parametro);
                    Log.Info(xmlDoc.OuterXml);
                }
            }
            catch { }
        }
        #endregion

        #region [Log Warn]
        public static void LogWarn(string mensagem)
        {
            try
            {
                if (Log.IsWarnEnabled)
                {
                    Log.Warn(mensagem);
                }
            }
            catch { }
        }

        public static void LogWarn(string mensagem, object arg0)
        {
            try
            {
                if (Log.IsWarnEnabled)
                {
                    Log.Warn(String.Format(mensagem, arg0));
                }
            }
            catch { }
        }

        public static void LogWarn(string mensagem, object arg0, object arg1)
        {
            try
            {
                if (Log.IsWarnEnabled)
                {
                    Log.Warn(String.Format(mensagem, arg0, arg1));
                }
            }
            catch { }
        }

        public static void LogWarn(string mensagem, object arg0, object arg1, object arg2)
        {
            try
            {
                if (Log.IsWarnEnabled)
                {
                    Log.Warn(String.Format(mensagem, arg0, arg1, arg2));
                }
            }
            catch { }
        }

        public static void LogWarn(string mensagem, object[] argumentos)
        {
            try
            {
                if (Log.IsWarnEnabled)
                {
                    Log.Warn(String.Format(mensagem, argumentos));
                }
            }
            catch { }
        }

        public static void LogWarn<T>(T parametro) where T : class
        {
            try
            {
                if (Log.IsWarnEnabled)
                {
                    var xmlDoc = Serialize.SerializeMe(parametro);
                    Log.Info(xmlDoc.OuterXml);
                }
            }
            catch { }
        }
        #endregion

        #region [Log Debug]
        public static void LogDebug(string mensagem)
        {
            try
            {
                if (Log.IsDebugEnabled)
                {
                    Log.Debug(mensagem);
                }
            }
            catch { }
        }

        public static void LogDebug(string mensagem, object arg0)
        {
            try
            {
                if (Log.IsDebugEnabled)
                {
                    Log.Debug(String.Format(mensagem, arg0));
                }
            }
            catch { }
        }

        public static void LogDebug(string mensagem, object arg0, object arg1)
        {
            try
            {
                if (Log.IsDebugEnabled)
                {
                    Log.Debug(String.Format(mensagem, arg0, arg1));
                }
            }
            catch { }
        }

        public static void LogDebug(string mensagem, object arg0, object arg1, object arg2)
        {
            try
            {
                if (Log.IsDebugEnabled)
                {
                    Log.Debug(String.Format(mensagem, arg0, arg1, arg2));
                }
            }
            catch { }
        }

        public static void LogDebug(string mensagem, object[] argumentos)
        {
            try
            {
                if (Log.IsDebugEnabled)
                {
                    Log.Debug(String.Format(mensagem, argumentos));
                }
            }
            catch { }
        }

        public static void LogDebug<T>(T parametro) where T : class
        {
            try
            {
                if (Log.IsDebugEnabled)
                {
                    var xmlDoc = Serialize.SerializeMe(parametro);
                    Log.Info(xmlDoc.OuterXml);
                }
            }
            catch { }
        }
        #endregion

        #region [Log Fatal]
        public static void LogFatal(Exception e)
        {
            try
            {
                if (!Log.IsFatalEnabled)
                {
                }
                else
                {
                    if (e != null)
                    {
                        Log.Fatal(String.Empty, e);
                    }
                }
            }
            catch { }
        }

        public static void LogFatal(string mensagem, Exception e)
        {
            try
            {
                if (!Log.IsFatalEnabled)
                {
                }
                else
                {
                    if (mensagem != null && e != null)
                    {
                        Log.Fatal(mensagem, e);
                    }
                }
            }
            catch { }
        }
        #endregion

        #region [Log Metodo Inicio]
        public static void LogMetodoIni()
        {
            try
            {
                if (Log.IsDebugEnabled)
                {
                    // Busca o método que invocou este
                    Log.Debug(GetLastMethod() + " - Início ");
                }
            }
            catch { }
        }

        public static void LogMetodoIni(String parametro)
        {
            try
            {
                if (Log.IsDebugEnabled)
                {
                    // Montar a string para o log
                    var sb = new StringBuilder();
                    sb.Append(GetLastMethod() + " - Início - Parâmetros(");

                    // Log do primeiro parâmetro
                    if (!String.IsNullOrWhiteSpace(parametro))
                    {
                        sb.Append(FormataXML(parametro));
                    }

                    sb.Append(")");

                    // Log dos parâmetros
                    Log.Debug(sb.ToString());
                }
            }
            catch { }
        }

        public static void LogMetodoIni(Object[] parametros)
        {
            try
            {
                if (Log.IsDebugEnabled)
                {
                    // Montar a string para o log
                    var sb = new StringBuilder();
                    sb.Append(GetLastMethod() + " - Início - Parâmetros(");

                    // Log do primeiro parâmetro
                    if (parametros.Length >= 1)
                    {
                        sb.Append(ToString(parametros[0]));
                    }

                    // Log dos demais parâmetros
                    for (var i = 1; i < parametros.Length; i++)
                    {
                        sb.Append("," + ToString(parametros[i]));
                    }

                    sb.Append(")");

                    // Log dos parâmetros
                    Log.Debug(sb.ToString());
                }
            }
            catch { }
        }

        public static void LogMetodoIni<T>(T parametro) where T : class
        {
            try
            {
                if (Log.IsDebugEnabled)
                {
                    // Montar a string para o log
                    var sb = new StringBuilder();
                    sb.AppendLine(GetLastMethod() + " - Início - Parâmetros(");

                    if (parametro != null)
                    {
                        var xmlDoc = Serialize.SerializeMe(parametro);
                        sb.AppendLine(FormataXML(xmlDoc.OuterXml));
                    }

                    sb.AppendLine(")");

                    // Log dos parâmetros
                    Log.Debug(sb.ToString());
                }
            }
            catch { }
        }

        public static void LogMetodoIniInfo()
        {
            try
            {
                if (Log.IsDebugEnabled)
                {
                    // Busca o método que invocou este
                    Log.Info(GetLastMethod() + " - Início ");
                }
            }
            catch { }
        }

        public static void LogMetodoIniInfo(String parametro)
        {
            try
            {
                if (Log.IsInfoEnabled)
                {
                    // Montar a string para o log
                    var sb = new StringBuilder();
                    sb.Append(GetLastMethod() + " - Início - Parâmetros(");

                    // Log do primeiro parâmetro
                    if (!String.IsNullOrWhiteSpace(parametro))
                    {
                        sb.Append(FormataXML(parametro));
                    }

                    sb.Append(")");

                    // Log dos parâmetros
                    Log.Info(sb.ToString());
                }
            }
            catch { }
        }

        public static void LogMetodoIniInfo(Object[] parametros)
        {
            try
            {
                if (Log.IsInfoEnabled)
                {
                    // Montar a string para o log
                    var sb = new StringBuilder();
                    sb.Append(GetLastMethod() + " - Início - Parâmetros(");

                    // Log do primeiro parâmetro
                    if (parametros.Length >= 1)
                    {
                        sb.Append(ToString(parametros[0]));
                    }

                    // Log dos demais parâmetros
                    for (var i = 1; i < parametros.Length; i++)
                    {
                        sb.Append("," + ToString(parametros[i]));
                    }

                    sb.Append(")");

                    // Log dos parâmetros
                    Log.Info(sb.ToString());
                }
            }
            catch { }
        }

        public static void LogMetodoIniInfo<T>(T parametro) where T : class
        {
            try
            {
                if (Log.IsInfoEnabled)
                {
                    // Montar a string para o log
                    var sb = new StringBuilder();
                    sb.AppendLine(GetLastMethod() + " - Início - Parâmetros(");

                    if (parametro != null)
                    {
                        var xmlDoc = Serialize.SerializeMe(parametro);
                        sb.AppendLine(FormataXML(xmlDoc.OuterXml));
                    }

                    sb.AppendLine(")");

                    // Log dos parâmetros
                    Log.Info(sb.ToString());
                }
            }
            catch { }
        }
        #endregion

        #region [Log Metodo Fim]
        public static void LogMetodoFim()
        {
            try
            {
                if (Log.IsDebugEnabled)
                {
                    // Busca o método que invocou este
                    Log.Debug(GetLastMethod() + " - Fim ");
                }
            }
            catch { }
        }

        public static void LogMetodoFim(String parametro)
        {
            try
            {
                if (Log.IsDebugEnabled)
                {
                    // Montar a string para o log
                    var sb = new StringBuilder();
                    sb.Append(GetLastMethod() + " - Fim - Parâmetros(");

                    // Log do primeiro parâmetro
                    if (!String.IsNullOrWhiteSpace(parametro))
                    {
                        sb.Append(FormataXML(parametro));
                    }

                    sb.Append(")");

                    // Log dos parâmetros
                    Log.Debug(sb.ToString());
                }
            }
            catch { }
        }

        public static void LogMetodoFim<T>(T parametro) where T : class
        {
            try
            {
                if (Log.IsDebugEnabled)
                {
                    // Montar a string para o log
                    var sb = new StringBuilder();
                    sb.AppendLine(GetLastMethod() + " - Fim - Retorno(");

                    if (parametro != null)
                    {
                        var xmlDoc = Serialize.SerializeMe(parametro);
                        sb.AppendLine(FormataXML(xmlDoc.OuterXml));
                    }
                    sb.AppendLine(")");

                    // Log dos parâmetros
                    Log.Debug(sb.ToString());
                }
            }
            catch { }
        }

        public static void LogMetodoFimInfo()
        {
            try
            {
                if (Log.IsInfoEnabled)
                {
                    // Busca o método que invocou este
                    Log.Info(GetLastMethod() + " - Fim ");
                }
            }
            catch { }
        }

        public static void LogMetodoFimInfo(String parametro)
        {
            try
            {
                if (Log.IsDebugEnabled)
                {
                    // Montar a string para o log
                    var sb = new StringBuilder();
                    sb.Append(GetLastMethod() + " - Fim - Parâmetros(");

                    // Log do primeiro parâmetro
                    if (!String.IsNullOrWhiteSpace(parametro))
                    {
                        sb.Append(FormataXML(parametro));
                    }

                    sb.Append(")");

                    // Log dos parâmetros
                    Log.Debug(sb.ToString());
                }
            }
            catch { }
        }

        public static void LogMetodoFimInfo<T>(T parametro) where T : class
        {
            try
            {
                if (Log.IsInfoEnabled)
                {
                    // Montar a string para o log
                    var sb = new StringBuilder();
                    sb.AppendLine(GetLastMethod() + " - Fim - Retorno(");

                    if (parametro != null)
                    {
                        var xmlDoc = Serialize.SerializeMe(parametro);
                        sb.AppendLine(FormataXML(xmlDoc.OuterXml));
                    }
                    sb.AppendLine(")");

                    // Log dos parâmetros
                    Log.Info(sb.ToString());
                }
            }
            catch { }
        }
        #endregion

        public static string ObjectToString<T>(T parametro) where T : class
        {
            var sb = new StringBuilder();
            try
            {
                sb.AppendLine(GetLastMethod() + " - Mensagem (");

                if (parametro != null)
                {
                    var xmlDoc = Serialize.SerializeMe(parametro);
                    sb.AppendLine(FormataXML(xmlDoc.OuterXml));
                }
                sb.AppendLine(")");

            }
            catch { }
            return sb.ToString();
        }
    }
}
