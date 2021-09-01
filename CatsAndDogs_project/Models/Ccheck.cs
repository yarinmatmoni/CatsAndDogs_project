////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Threading.Tasks;

////namespace CatsAndDogs_project.Models
////{
////    public class Ccheck
////    {

////        public async Task<IActionResult> JoinDishRestaurant(int? id)
////        {
////            ViewJoin viewJoin = new ViewJoin();

////            //viewJoin.Restaurants = null;
////            viewJoin.Dishes = null;

////            if (id == null)
////            {
////                return NotFound();
////            }

////            //var review = from r in _context.Review.Include(r => r.App).Include(r => r.Name).Include(r => r.UserName)
////            //           join usr in _context.User on r.UserNameId equals usr.Id
////            //           where id == r.UserNameId
////            //           select r;




////            var allRestaurants = await _context.Restaurant.ToListAsync();
////            //var allDishes = await _context.Dish.ToListAsync();
////            var allDishes = await _context.Dish.Where(d => d.ID == id).ToListAsync();

////            //var joinResult =
////            //        from r in allRestaurants // This is the column that connects the 2 tables.
////            //        join d in allDishes
////            //        on r.ID equals d.RestaurantID into result
////            //        select result;

////            var query1 = from d in allDishes
////                         join r in allRestaurants
////                             on d.RestaurantID equals r.ID
////                         select new { d, r };

////            var query2 = from d in allDishes
////                         join r in allRestaurants
////                             on d.RestaurantID equals r.ID into result
////                         select result;

////            var query3 = from d in allDishes
////                         join r in allRestaurants
////                             on d.RestaurantID equals r.ID
////                         select d;

////            var query4 = from d in allDishes
////                         join r in allRestaurants
////                             on d.RestaurantID equals r.ID
////                         where id == d.RestaurantID
////                         select d;
////            // קח את כל שמות המסעדות, מזג אותן עם כל המנות, היכן שהאיידי של מסעדה במסדר נתונים של מנות זהה לאיידי של רשימת המסעדות
////            //  transaction/photo = dish table. user/person = restaurant table

////            //if (query1 == null)
////            //{
////            //    return NotFound();
////            //}

////            viewJoin.Restaurants = query2.Distinct().SelectMany(x => x).ToList();
////            viewJoin.Dishes = query3.ToList();
////            //viewJoin.Restaurants = rest.Distinct().Select(x => x).ToList();

////            return View(viewJoin);
////        }
////    }






//public async Task<IActionResult> Index()
//{
//    var allRestaurants = await _context.Restaurant.ToListAsync();
//    //var allDishes = await _context.Dish.ToListAsync();

//    var resList = new List<Restaurant>
//    {

//    };

//    if (User.IsInRole("Admin") || User.IsInRole("rManager"))
//    {
//        var userEmail = User.Claims.ToList()[0].Value;
//        foreach (var user in _context.User) //Get the currect user that is log in.
//        {
//            if (user.Email == userEmail)
//            {
//                if (user.RestaurantId != null)
//                {
//                    var allUsers = await _context.User.Where(u => u.Email == userEmail).ToListAsync();
//                    var uRestaurant = from r in allRestaurants
//                                      join u in allUsers
//                                      on r.ID equals u.RestaurantId
//                                      select r;

//                    resList.Add(uRestaurant.First());
//                    foreach (var res in allRestaurants)
//                    {
//                        if (res != resList[0])
//                            resList.Add(res);
//                    }

//                    return View(resList.ToList());
//                }
//                else
//                {
//                    break;
//                }
//            }
//        }
//    }
//    var restaurant = from m in _context.Restaurant
//                     select m;

//    return View(restaurant);
//}





////    //var catsAndDogs_projectContext = _context.GuideDog.Include(g => g.BreedDog);

////    //var allList = await _context.GuideDog.ToListAsync();

////    //var allDogs = await _context.Dog_2.ToListAsync();
////    //var allGuides = await _context.GuideDog.ToListAsync();

////    //var joinBG = from a in allGuides
////    //             join b in allDogs
////    //             on a.BreedDog equals b.ListBreed
////    //             select (a);



////    //allList.Add(joinBG.First());
////    //return View(await joinBG.ToList());
////    //var uRestaurant = from r in allRestaurants
////    //                  join u in allUsers
////    //                  on r.ID equals u.RestaurantId
////    //                  select r;

////    //return View(await catsAndDogs_projectContext.ToListAsync());





////    ///////////////////////
////    ///the fix:
////    ///

////var allDogs = await _context.Dog_2.ToListAsync();
////var allGuides = await _context.GuideDog.ToListAsync();

////var output = from a in allDogs
////             join b in allGuides
////             on a.ListBreed.ElementAt(0) equals b.BreedDog
////             select (b.BreedDog, a.Name, a.Description, a.Age, a.Image, b.Description, b.AvgHeight, b.AvgLife, b.AvgWeight, b.Characteristics, b.Description, b.Health);




////return View(output.ToList());









//// 31.8.21  Dog_2Controller


////var allDogs = await _context.Dog_2.ToListAsync();
////var allGuides = await _context.GuideDog.ToListAsync();

////var output = from a in allDogs
////             join b in allGuides
////             on a.ListBreed.ElementAt(0) equals b.BreedDog
////             select (a.Name, b.BreedDog, a.Image, a.Age, a.Color, a.Description, a.Gender, a.LifeExpectancy, a.Match, a.ListBreed, a.Size, b.Description);


////output = output.ToList();

//////return View("JoinDogBreed", output.ToList());
////return View(dog_2);


////public async Task<IActionResult> moreDetails(int? id)
////{


////}


//// GuideDogsController

////var allDogs = await _context.Dog_2.ToListAsync();
////var allGuides = await _context.GuideDog.ToListAsync();

////var output = from a in allDogs
////             join b in allGuides
////             on a.ListBreed.ElementAt(0) equals b.BreedDog
////             select (b.BreedDog /*a.Name, a.Age, b.AvgLife, a.Description, b.Description, b.Health, b.Training*/);



////return View("JoinDogBreed", output.ToList());
///

// בקונטרולר של הכלב:

//public async Task<IActionResult> DogGuide(int? id)// מקבלים id של כלב
//{
//    var allDogs = await _context.Dog_2.ToListAsync();
//    var allGuides = await _context.GuideDog.ToListAsync();

//    var dog = _context.Dog_2.Where(a => a.Id.Equals(id));// מוצא את הכלב הרלוונטי
//    var listbreed = dog.ElementAt(0).ListBreed;
//    var GuidesListForDog = new List<GuideDog>();// רשימה של מדריכים של הכלב הרלוונטי


//    var relevantGuides = from a in allDogs
//                         join b in allGuides
//                         on a.ListBreed.First() equals b.BreedDog.Name
//                         select b;



//}