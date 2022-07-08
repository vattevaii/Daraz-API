using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daraz.Application.Services.ProductServices
{
    public record ProductResult(
        int ProductId,
        string Name,
        string Description,
        double Price,
        double Discount
    );
}
