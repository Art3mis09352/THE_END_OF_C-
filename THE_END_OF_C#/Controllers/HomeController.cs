using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using THE_END_OF_C_.Models;

namespace THE_END_OF_C_.Controllers
{
    public class HomeController : Controller
    {
        Context db;
        public HomeController(Context context) 
        {
            db = context; 
        }
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        public async Task<IActionResult> Index_TGROUP()
        {
            return View(await db.TGroup.ToListAsync());
        }
        public async Task<IActionResult> Index_TRELATION()
        {
            return View(await db.TRelation.ToListAsync());
        }
        public async Task<IActionResult> Index_TPROPERTY()
        {
            return View(await db.TPROPERTY.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TGROUP user)
        {
            
            var Tgr = db.TGroup.FirstOrDefault();
            if (Tgr == null)
            {
                var newEntity = new TGROUP()
                {
                    Id = 1,
                    Name = user.Name
                };
                db.TGroup.Add(newEntity);
            }
            else
            {
                var maxId = db.TGroup.Max(x => x.Id) + 1;
                var newEntity = new TGROUP()
                {
                    Id = maxId,
                    Name = user.Name
                };
                db.TGroup.Add(newEntity);
            }
            await db.SaveChangesAsync();
            return RedirectToAction("Index_TGROUP");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                TGROUP? user = await db.TGroup.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                {
                    db.TGroup.Remove(user);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index_TGROUP");
                }
            }
            return NotFound();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                TGROUP? user = await db.TGroup.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null) return View(user);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(TGROUP user)
        {
            db.TGroup.Update(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index_TGROUP");
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
        public IActionResult Create_TPROPERTY()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create_TPROPERTY(TPROPERTY property)
        {
            var existingProperty = db.TPROPERTY.FirstOrDefault();
            if (existingProperty == null)
            {
                var newEntity = new TPROPERTY()
                {
                    id_prop = 1,
                    prop_name = property.prop_name,
                    value = property.value,
                    group_id = property.group_id
                };
                db.TPROPERTY.Add(newEntity);
            }
            else
            {
                var maxId = db.TPROPERTY.Max(x => x.id_prop) + 1;
                var newEntity = new TPROPERTY()
                {
                    id_prop = maxId,
                    prop_name = property.prop_name,
                    value = property.value,
                    group_id = property.group_id
                };
                db.TPROPERTY.Add(newEntity);
            }
            await db.SaveChangesAsync();
            return RedirectToAction("Index_TPROPERTY");
        }

        [HttpPost]
        public async Task<IActionResult> Delete_TPROPERTY(long? id)
        {
            if (id != null)
            {
                TPROPERTY? property = await db.TPROPERTY.FirstOrDefaultAsync(p => p.id_prop == id);
                if (property != null)
                {
                    db.TPROPERTY.Remove(property);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index_TPROPERTY");
                }
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit_TPROPERTY(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var property = await db.TPROPERTY.AsNoTracking().FirstOrDefaultAsync(p => p.id_prop == id);

            if (property == null)
            {
                return NotFound();
            }

            return View(property);
        }

        [HttpPost]
        public async Task<IActionResult> Edit_TPROPERTY(TPROPERTY property)
        {
            var existingProperty = await db.TPROPERTY.FindAsync(property.id_prop);

            if (existingProperty == null) // Проверяем, есть ли запись в базе
            {
                return NotFound(); // Ошибка 404, если объект удален
            }

            db.Entry(existingProperty).CurrentValues.SetValues(property); // Обновляем значения
            await db.SaveChangesAsync();
            return RedirectToAction("Index_TPROPERTY");
        }


    }

}
