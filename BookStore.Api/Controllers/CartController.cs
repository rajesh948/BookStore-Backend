using BookStore.Models.Models;
using BookStore.Models.ViewModels;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Api.Controllers
{
    [ApiController]
    [Route("cart")]

    public class CartController : Controller
    {
        private readonly CartRepository _cartRepository = new CartRepository();

        [HttpGet]
        [Route("list")]
        public IActionResult GetCartItems(int UserId, int pageIndex = 1, int pageSize = 10)
        {
            ListResponse<Cart> carts = _cartRepository.GetCartItems(UserId, pageIndex, pageSize);
            ListResponse<GetCartModel> cartModels = new ListResponse<GetCartModel>()
            {
                records = carts.records.Select(c => new GetCartModel(c.Id, c.Userid, new BookModel(c.Book), c.Quantity)).ToList(),
                TotalRecords = carts.TotalRecords
            };
            return Ok(cartModels);
        }


        [HttpPost]
        [Route("add")]
        public ActionResult<CartModel> AddCart(CartModel model)
        {
            if (model == null)
                return BadRequest();

            Cart cart = new Cart()
            {
                Id = model.Id,
                Quantity = 1,
                Bookid = model.BookId,
                Userid = model.UserId
            };
            cart = _cartRepository.AddCart(cart);
            if (cart == null)
            {
                return StatusCode(500);
            }
            return new CartModel(cart);
        }



        [HttpPut]
        [Route("update")]
        public IActionResult UpdateCart(CartModel model)
        {
            if (model == null)
                return BadRequest();

            Cart cart = new Cart()
            {
            Id = model.Id,
            Userid = model.UserId,
            Bookid = model.BookId,
            Quantity = model.Quantity,
        };
            cart = _cartRepository.UpdateCart(cart);
            return Ok(new CartModel(cart));
        
        }

     
        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteCart(int id)
        {
            if (id == 0)
                return BadRequest("id is null");
            bool response = _cartRepository.DeleteCart(id);
            return Ok(response);
        }

    }
}
