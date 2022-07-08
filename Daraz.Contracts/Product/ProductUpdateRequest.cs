using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daraz.Contracts.Product
{
    public record ProductUpdateRequest(
        int Id,
        string Name,
        string Description,
        double Price,
        double Discount
        );
}
