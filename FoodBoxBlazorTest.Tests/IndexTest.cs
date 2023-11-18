using Bunit;
using FrontEnd.Pages;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.CodeAnalysis.Options;
using Newtonsoft.Json.Linq;
using Xunit;

namespace FoodBoxBlazorTest.Tests
{
    /// <summary>
    /// 
    /// </summary>
    public class IndexTest
    {
        /*[Fact]
        public void Markup()
        {
            //Arrange 
            using var ctx = new TestContext();

            //Act
            var renderedComponent = ctx.RenderComponent<FrontEnd.Pages.Index>();

            //Assert
            var PageTitleElement = renderedComponent.Find("PageTitle");
            PageTitleElement.MarkupMatches("<PageTitle>Home</PageTitle>");
        }*/

        [Fact]
        public void InitialRender_WithEventCallBack()
        {
            // Arrange
            var ctx = new TestContext();
            var eventCall = false;

            // Act

            var comp = ctx.RenderComponent<FrontEnd.Pages.OrderingItem>(parameters => parameters
                .Add(p => p.ItemName, "Salmon")
                .Add(pri => pri.price, (decimal)12.99)
                .Add(qan => qan.quantityItem, 1)
                .Add(rest => rest.RestaurantId, 1)
                .Add(selectedItm => selectedItm.SelectedItemId, 1)
                .Add(p => p.OnSubmit, () => { eventCall = true; })
            );

            // Assert
            var expected =
                @"<div class='background'>
            <div class='container'>
                <div class=""screen"">

                    <div class=""screen-body"">
                        <div class=""screen-body-item left"">
                            <div class=""app-title"">
                                <span>@menuItems[SelectedItemId].ItemName</span>
                            </div>
                            <div class=""app-contact"">CONTACT INFO : +1 314 928 0595</div>
                        </div>
                        <div class=""screen-body-item"">
                            <div class=""app-form"">
                                <div class=""app-form-group"">
                                    <InputSelect id=""quantity"" class=""form-control""
                                    @bind-Value=""@quantityItem"">
                                        @foreach (int num in quantity)
                                        {
                                            <option value=""@num"">@num</option>
                                        }
                                    </InputSelect>
                                </div>
                                <div class=""app-form-group buttons"">
                                    <button type=""submit"" class=""app-form-button""
                                            disabled=""@IsBusy"" @onclick=""HandleSubmit"">
                                        Submit
                                    </button>
                                    <div>Price: @(quantityItem * restaurantsAndItems[RestaurantId - 1].RestaurantItems.Where(id => id.ItemId == (SelectedItemId + 1)).ToList()[0].Price)</div>
                                    <div>itemOrder for testing:</div>
                                    <div>Id: @selectedItemOrder.ItemId</div>
                                    <div>Quantity: @selectedItemOrder.Quantity</div>
                                    <div>Price: @selectedItemOrder.ItemPrice</div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>";

            comp.MarkupMatches(expected);
            Assert.False(eventCall);
        }

        [Fact]
        public void OnSubmitEventTriggeredOnClick()
        {
            // arrange
            var ctx = new TestContext();
            var eventCalled = false;

            var comp = ctx.RenderComponent<FrontEnd.Pages.OrderingItem>(parameters => parameters
                .Add(p => p.ItemName, "Salmon")
                .Add(pri => pri.price, (decimal)10.00)
                .Add(qan => qan.quantityItem, 1)
                .Add(rest => rest.RestaurantId, 1)
                .Add(selectedItm => selectedItm.SelectedItemId, 1)
                .Add(p => p.OnSubmit, () => { eventCalled = true; })
            );

            // act
            comp.Find("button[type=submit]").Click();

            // assert
            Assert.True(eventCalled);
        }


    }
}