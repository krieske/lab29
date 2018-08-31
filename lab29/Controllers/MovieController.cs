using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using lab29.Models;


namespace lab29.Controllers
{
    public class MovieController : ApiController
    {
        // list of all movies
        [HttpGet]
        public List<Movies> GetAllMovies()
        {
            // URL: http://localhost:53946/api/Movie/GetAllMovies

            // create the ORM
            lab29Entities ORM = new lab29Entities();

            // get all movies from the ORM
            List<Movies> movie = ORM.Movies.ToList();

            // return the list of movies
            return movie;
        }


        [HttpGet]
        public List<Movies> GetMovieCategory(string category)
        {
            // URL: http://localhost:53946/api/Movie/GetMovieCategory?category=category

            // create the ORM
            lab29Entities ORM = new lab29Entities();

            // return list of movies in specific category
            return ORM.Movies.Where(x => x.category.ToLower() == category.ToLower()).ToList();
        }

        [HttpGet]
        public Movies GetRandomMovie()
        {
            // URL: http://localhost:53946/api/Movie/GetRandomMovie


            lab29Entities ORM = new lab29Entities();

            Random r = new Random();

            List<Movies> randommov = ORM.Movies.ToList();

            return randommov[r.Next(0, randommov.Count)];
        }

        private Movies _GetRandomMovie(List<Movies> rmov)
        {
            Random r = new Random();

            return rmov[r.Next(0, rmov.Count)];
        }


        // random list of movies (user chooses what category)
        [HttpGet]
        public Movies GetRandomCategory(string cat)
        {
            // URL: http://localhost:53946/api/Movie/GetRandomCategory?cat={cat}

            // create the ORM
            lab29Entities ORM = new lab29Entities();

            List <Movies> temp = ORM.Movies.Where(x => x.category.ToLower() == cat.ToLower()).ToList();
            return _GetRandomMovie(temp);
        }


        // random list of movies (user chooses how many random movies to generate)
        [HttpGet]
        public List <Movies> GetRandomMovieList(int count)
        {
            // URL: http://localhost:53946/api/Movie/GetRandomMovieList?count={count}

            lab29Entities ORM = new lab29Entities();

            List<Movies> temp = new List<Movies>();
            List<Movies> temp2 = ORM.Movies.ToList();

            for(int i = 0; i < count; i++)
            {
                Movies rnmo = _GetRandomMovie(temp2);
                temp.Add(rnmo);
                temp2.Remove(rnmo);

                if(temp2.Count == 0) // only prints the maximum number of movies in the database
                {
                    return temp;
                }
            }

            return temp;
        }


        // list movie categories


        // description about a specific movie

        
        // list movies by keyword in title




    }
}