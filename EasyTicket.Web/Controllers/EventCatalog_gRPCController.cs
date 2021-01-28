using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EasyTicket.Grpc;
using EasyTicket.Web.Models.grpc;
using Microsoft.AspNetCore.Mvc;

namespace EasyTicket.Web.Controllers
{
    public class EventCatalog_gRPCController : Controller
    {
        private readonly Events.EventsClient eventCatalogService;

        public EventCatalog_gRPCController(Events.EventsClient eventCatalogService)
        {
            this.eventCatalogService = eventCatalogService;
        }

        public async Task<IActionResult> Index(Guid categoryId)
        {
            var getCategories = eventCatalogService.GetAllCategoriesAsync(
                new GetAllCategoriesRequest());
            var getEvents = categoryId == Guid.Empty ? eventCatalogService.GetAllAsync(
                new GetAllEventsRequest()) :
                eventCatalogService.GetAllByCategoryIdAsync(
                    new GetAllEventsByCategoryIdRequest { CategoryId = categoryId.ToString() });
            await Task.WhenAll(new Task[] { getCategories.ResponseAsync, getEvents.ResponseAsync });

            return View(
                new EventListModel
                {
                    Events = getEvents.ResponseAsync.Result.Events,
                    Categories = getCategories.ResponseAsync.Result.Categories,
                    SelectedCategory = categoryId
                }
            );
        }

        [HttpPost]
        public IActionResult SelectCategory([FromForm] Guid selectedCategory)
        {
            return RedirectToAction("Index", new { categoryId = selectedCategory });
        }

        public async Task<IActionResult> Detail(Guid eventId)
        {
            var ev = await eventCatalogService.GetByEventIdAsync(new GetByEventIdRequest { EventId = eventId.ToString() });
            return View(ev.Event);
        }
    }
}