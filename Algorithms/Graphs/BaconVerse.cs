using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using System.Collections;

namespace Graphs
{
    internal class BaconVerse
    {
        public List<Actor> Actors { get; private set; } = new List<Actor>();

        internal void AddActor(Actor actor)
        {
            Actors.Add(actor);
        }

        internal int CalculateBaconNumber(Actor source, Actor target)
        {
            var queue = new Queue<(Actor actor,int stepsAway)>();
            var visited = new HashSet<Actor>();
            var stepsAway = new Dictionary<Actor, int>();

            queue.Enqueue((source,1));


            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                visited.Add(current.actor);
                foreach (var currentMovie in current.actor.Movies)
                {
                    var ActorWhoStaredWithCurrent = Actors
                        .Where(costar => costar.Movies.Contains(currentMovie))
                        .Where(costar => !visited.Contains(costar))
                        .ToList()
                        ;
                    foreach (var coStart in ActorWhoStaredWithCurrent)
                    {
                        if (coStart ==  target) 
                            return current.stepsAway;
                        queue.Enqueue((coStart, current.stepsAway + 1));
                    }
                }
            }
            return 1;
        }
        
    }


    public class KevinBaconTests
    {
        [Fact]
        public void ThereAre2LinksBetweenPennAndKevinBacon()
        {
            ///arrange 
            var toyStory = "Toy Story";
            var baby = "She's Having a Baby";

            var penn = new Actor();
            penn.AddMovie(toyStory);
            penn.Name = "Penn";

            var john = new Actor();
            john.AddMovie(toyStory);
            john.AddMovie(baby);
            john.Name = "John";

            var kevin = new Actor();
            kevin.AddMovie(baby);
            kevin.Name = "Kevin";

            var baconVerse = new BaconVerse();
            baconVerse.AddActor(penn);
            baconVerse.AddActor(john);
            baconVerse.AddActor(kevin);


            baconVerse.CalculateBaconNumber(penn,kevin).Should().Be(2);


        }

        [Fact]
        public void ThereAre1LinksBetweenPennAndKevinBacon()
        {
            ///arrange 
            var toyStory = "Toy Story";
            var baby = "She's Having a Baby";

            var penn = new Actor();
            penn.AddMovie(toyStory);
            penn.Name = "Penn";

            var john = new Actor();
            john.AddMovie(toyStory);
            john.AddMovie(baby);
            john.Name = "John";

            var kevin = new Actor();
            kevin.AddMovie(baby);
            kevin.AddMovie(toyStory);
            kevin.Name = "Kevin";

            var baconVerse = new BaconVerse();
            baconVerse.AddActor(penn);
            baconVerse.AddActor(john);
            baconVerse.AddActor(kevin);


            baconVerse.CalculateBaconNumber(penn, kevin).Should().Be(1);


        }













        [Fact]
        public void TestDepthFirstSearch()
        {
            var baconverse = new BaconVerse();
        }
    }

    internal class Actor
    {
        public Actor()
        {
        }
        public override string ToString()
        {
            return Name;
        }
        public string Name { get; internal set; }
        public List<string> Movies { get; private set; } = new List<string>();

        internal void AddMovie(string movie)
        {
            Movies.Add(movie);
        }
    }
}
