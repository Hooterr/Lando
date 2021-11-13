using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lando.PageModels
{
    public abstract class BasePageModel : BindableObject
    {
        public virtual Task InitializeAsync()
        {
            return Task.CompletedTask;
        }
    }
}
