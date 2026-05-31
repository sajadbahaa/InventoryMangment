using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Common.ApiResponse
{
    public class SuccessApiResponse:ControllerBase
    {

        protected IActionResult NotContentResponse() => base.NoContent();
        protected IActionResult OKResponse<TEntity> (TEntity entity) => base.Ok(entity);
    }
}
