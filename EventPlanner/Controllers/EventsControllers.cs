using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EventPlanner.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EventPlanner.Controllers
{
    public class EventsController : Controller {
        private EventPlannerContext _dbConnector;
    
        public EventsController(EventPlannerContext connect)
        {
            _dbConnector = connect;
        }        
        // GET: /Home/
        [HttpGet]
        [Route("events")]
        public IActionResult Events()
        {
            int? id = HttpContext.Session.GetInt32("Id");
            User curUser = _dbConnector.users.Where(user => user.UserId == (int)id).SingleOrDefault();
            if(HttpContext.Session.GetInt32("Id") != null){
                List<Event> allEvents = _dbConnector.events
                                                    .Include(inv => inv.Attendees)
                                                    .ToList();
                List<Invite> allInvites = _dbConnector.invites
                                                    .Include(inv => inv.User)
                                                    .Include(inv => inv.Event)
                                                    .ToList();
                ViewBag.allInvites = allInvites;
                ViewBag.allEvents = allEvents;
                ViewBag.id = (int)id;
                ViewBag.name = curUser.FirstName;
                return View("Events");
           }
            return RedirectToAction("Index", "Users");
        }
        [HttpGet]
        [Route("newevent")]
        public IActionResult NewEvent()
        {
            if(HttpContext.Session.GetInt32("Id") != null){
                ViewBag.error = HttpContext.Session.GetString("WrongDate");
                ViewBag.EventName = HttpContext.Session.GetString("EventName");
                ViewBag.EventAddress = HttpContext.Session.GetString("EventAddress");
                ViewBag.Date = HttpContext.Session.GetString("Date");
                return View("CreateEvent");
            }
            return RedirectToAction("Index", "Users");
        }
        [HttpGet]
        [Route("delete/{evntid}")]
        public IActionResult Delete(int evntid)
        {
            if(HttpContext.Session.GetInt32("Id") != null){
                Event thisEvent = _dbConnector.events.Where(evnt => evnt.EventId == evntid).SingleOrDefault();
                _dbConnector.events.Remove(thisEvent);
                _dbConnector.SaveChanges();
                return RedirectToAction("Events");
           }
            return RedirectToAction("Index", "Users");
        }
        [HttpGet]
        [Route("unrsvp/{evntid}")]
        public IActionResult UnRsvp(int evntid)
        {
            
            if(HttpContext.Session.GetInt32("Id") != null){
                int? id = HttpContext.Session.GetInt32("Id");
                Invite thisInvite = _dbConnector.invites.Where(evnt => evnt.EventId == evntid && evnt.UserId == (int)id).SingleOrDefault();
                _dbConnector.invites.Remove(thisInvite);
                _dbConnector.SaveChanges();
                return RedirectToAction("Events");
           }
            return RedirectToAction("Index", "Users");
        }
        [HttpPost]
        [Route("addevent")]
        public IActionResult AddEvent(Event newEvent)
        {  
            if(HttpContext.Session.GetInt32("Id") != null){
                HttpContext.Session.SetString("WrongDate", "");
                HttpContext.Session.SetString("EventName", "");
                HttpContext.Session.SetString("EventAddress", "");
                if(newEvent.Date >= DateTime.Today){
                    newEvent.UserID = (int)HttpContext.Session.GetInt32("Id");
                    _dbConnector.events.Add(newEvent);
                    _dbConnector.SaveChanges();
                    return RedirectToAction("Events");
                    }
                else {
                    HttpContext.Session.SetString("WrongDate", "Date needs to be a future date!");
                    HttpContext.Session.SetString("EventName", newEvent.EventName);
                    HttpContext.Session.SetString("EventAddress", newEvent.Address);
                    HttpContext.Session.SetString("Date", newEvent.Date.ToString("yyyy-MM-dd"));
                    return RedirectToAction("newevent");
                }
            }
            return RedirectToAction("Index", "Users");
        }
        [HttpGet]
        [Route("showevent/{evntid}")]
        public IActionResult ShowEvent(int evntid)
        {
            if(HttpContext.Session.GetInt32("Id") != null){
                Event thisEvent = _dbConnector.events.Where(evnt => evnt.EventId == evntid).SingleOrDefault();
                List<Invite> allInvites = _dbConnector.invites.Where(inv => inv.EventId == evntid)
                                                    .Include(inv => inv.User)
                                                    .ToList();
                string address = thisEvent.Address;
                ViewBag.address = address.Replace(" ", "+");;
                ViewBag.allInvites = allInvites;
                ViewBag.thisEvent = thisEvent;
                return View("ShowEvent");
           }
            return RedirectToAction("Index", "Users");
        }
        [HttpPost]
        [Route("reset/{evntid}")]
        public IActionResult Reset(int evntid, Event newEvent)
        {
            if(HttpContext.Session.GetInt32("Id") != null){
                Event thisEvent = _dbConnector.events.Where(evnt => evnt.EventId == evntid).SingleOrDefault();
                thisEvent.Address = newEvent.Address;
                thisEvent.Date = newEvent.Date;
                thisEvent.EventName = newEvent.EventName;
                _dbConnector.SaveChanges();
                return RedirectToAction("Events");
           }
            return RedirectToAction("Index", "Users");
        }
        [HttpGet]
        [Route("edit/{evntid}")]
        public IActionResult Edit(int evntid)
        {
            if(HttpContext.Session.GetInt32("Id") != null){
                Event thisEvent = _dbConnector.events.Where(evnt => evnt.EventId == evntid).SingleOrDefault();
                ViewBag.date = thisEvent.Date.ToString("yyyy-MM-dd");
                ViewBag.thisEvent = thisEvent;
                return View("EditEvent");
           }
            return RedirectToAction("Index", "Users");
        }
        [HttpGet]
        [Route("rsvp/{evntid}")]
        public IActionResult Rsvp(int evntid, Invite newInvite)
        {
            int? id = HttpContext.Session.GetInt32("Id");
            if(HttpContext.Session.GetInt32("Id") != null){
                newInvite.UserId = (int)id;
                newInvite.EventId = evntid;
                _dbConnector.invites.Add(newInvite);
                _dbConnector.SaveChanges();
                return RedirectToAction("Events");
           }
            return RedirectToAction("Index", "Users");
        }
        [HttpPost]
        [Route("logout")]
        public IActionResult Logout()
        {
            ViewBag.errors = new List<string>();
            // TempData["error"] = "string";
            if(HttpContext.Session.GetInt32("Id") != null){
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Users");
            }
            return RedirectToAction("Index", "Users");;
        }        
    }
}
