﻿

using SimpleMVC.ByTheCakeApp.Controllers;
using SimpleMVC.Server.Contracts;

namespace SimpleMVC.ByTheCakeApp
{
    public class ByTheCakeApplication
    {
        public void Configure(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig.Get("/", request => 
                    new HomeController().Index());

            appRouteConfig.Get("/about", request => 
                    new HomeController().About());

            appRouteConfig.Get("/add", request => 
                    new CakeController().AddCakeForm());

            appRouteConfig.Post("/add", request => 
                    new CakeController().RegisterCake(request.FormData["name"], request.FormData["price"]));

            appRouteConfig.Get("/search", request => 
                    new CakeController().SearchCakeForm(request));

            appRouteConfig.Get("/login", request =>
                    new AccountController().Login());

            appRouteConfig.Post("/login", request =>
                    new AccountController().Login(request));

            appRouteConfig.Post("/logout", request =>
                    new AccountController().Logout(request));

            appRouteConfig.Post("/order", request =>
                    new ShoppingCartController().AddProduct(request));

            appRouteConfig.Get("/cart", request =>
                    new ShoppingCartController().CartReview(request));

            appRouteConfig.Get("/finish", request =>
                    new ShoppingCartController().FinishOrder(request));
        }
    }
}
