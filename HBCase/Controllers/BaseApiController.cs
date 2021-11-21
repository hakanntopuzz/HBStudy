﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HBCase.Controllers
{
    public class BaseApiController : ControllerBase
    {
        protected readonly IMediator _mediator;

        public BaseApiController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}