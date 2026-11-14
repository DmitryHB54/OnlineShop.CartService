using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.CartService.Application.Dtos;
using OnlineShop.CartService.Application.Features.Carts.Commands.AddItem;
using OnlineShop.CartService.Application.Features.Carts.Commands.RemoveItem;
using OnlineShop.CartService.Application.Features.Carts.Queries.GetCart;

namespace OnlineShop.CartService.WebApi.Controllers;

[ApiController]
[Route("api/cart")]
[Authorize] 
public class CartController : ControllerBase
{
    private readonly IMediator _mediator;

    public CartController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(CartDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCart(CancellationToken cancellationToken)
    {
        var userId = GetUserId();
        return Ok(await _mediator.Send(new GetCartQuery(userId), cancellationToken));
    }

    [HttpPost("items")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddItem([FromBody] AddItemRequest request, CancellationToken cancellationToken)
    {
        var userId = GetUserId();
        await _mediator.Send(
            new AddItemCommand(userId, request.ProductId, request.Quantity), cancellationToken);
        return NoContent();
    }

    [HttpDelete("items/{productId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> RemoveItem([FromRoute] Guid productId, CancellationToken cancellationToken)
    {
        var userId = GetUserId();
        await _mediator.Send(new RemoveItemCommand(userId, productId), cancellationToken);
        return NoContent();
    }

    private Guid GetUserId()
    {
        string? userIdClaim = User.FindFirst("userId")?.Value;

        if (userIdClaim is null || !Guid.TryParse(userIdClaim, out var userId))
        {
            var allClaims = string.Join(", ", User.Claims.Select(c => $"{c.Type}={c.Value}"));
            throw new UnauthorizedAccessException($"User ID claim is missing or invalid. Claims: {allClaims}");
        }

        return userId;
    }
}

public record AddItemRequest(Guid ProductId, int Quantity);