using Microsoft.AspNetCore.Mvc.ModelBinding;
using SistemaDeGestaoEscolar.Common;
using System;
using System.Globalization;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

namespace SistemaDeGestaoEscolar.WebApp
{
    public class GestaoEntityBinder : IModelBinder
    {
        private readonly ILog _log;

        public GestaoEntityBinder(ILog log)
        {
            _log = log;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            // cria o "model"
            var modelType = bindingContext.ModelMetadata.UnderlyingOrModelType;
            var model = Activator.CreateInstance(modelType);

            // obtém o modelState
            var modelState = bindingContext.ModelState;

            try
            {
                // recupera os campos do FORM
                var request = bindingContext.HttpContext.Request;
                if (request.HasFormContentType)
                {
                    var form = request.Form;

                    // itera em cada propriedade usando Reflection
                    foreach (var prop in modelType.GetProperties())
                    {
                        if (form.ContainsKey(prop.Name))
                        {
                            var formValue = form[prop.Name];

                            // atribui campo decimal
                            if (prop.PropertyType == typeof(decimal))
                            {
                                var value = decimal.Parse(formValue, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture);
                                prop.SetValue(model, value);
                            }
                            // atribui campo int
                            else if (prop.PropertyType == typeof(int))
                            {
                                var value = int.Parse(formValue);
                                prop.SetValue(model, value);
                            }
                            // atribui campo string
                            else if (prop.PropertyType == typeof(string))
                            {
                                var value = formValue.ToString();
                                prop.SetValue(model, value);
                            }

                            // preenche a validação do campo no modelState
                            modelState.SetModelValue(prop.Name, new ValueProviderResult(formValue));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var isFormatException = (ex is FormatException);
                if (!isFormatException && ex.InnerException != null)
                {
                    ex = ExceptionDispatchInfo.Capture(ex.InnerException).SourceException;
                }

                _log.Error(ex.StackTrace);
            }

            bindingContext.Result = ModelBindingResult.Success(model);
            return Task.CompletedTask;
        }
    }
}