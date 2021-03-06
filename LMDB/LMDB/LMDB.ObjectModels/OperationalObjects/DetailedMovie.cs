﻿using LMDB.ObjectModels.Contracts;
using LMDB.ObjectModels.OperationalObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LMDB.ObjectModels.Models
{
    /// <summary>
    /// Class representing a movie object.
    /// </summary>
    public class DetailedMovie : IComparable<DetailedMovie>, IMotionPictureData
    {
        public DetailedMovie()
        {
            this.Genres = new List<Genre>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<Genre> Genres { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Overview { get; set; }

        public string Rating { get; set; }

        public decimal Budget { get; set; }

        public int Runtime { get; set; }

        public override string ToString()
        {
            return string.Format(@"
|| ID: {0}
|| Title: {1}
|| Genres: {2}
|| Release Date: {3}
|| Rating: {4}
|| Runtime: {5} minutes
|| Budget: {6}$
|| Overview: {7}", this.Id, this.Title, string.Join(", ", this.Genres), this.ReleaseDate.Date.ToShortDateString(), this.Rating, this.Runtime, this.Budget, this.Overview);
        }

        /// <summary>
        /// Implemented comparer for proper addition in the SortedSet collection.
        /// Objects are compared by "Title" property.
        /// </summary>
        /// <param name="other">movie to be compared</param>
        /// <returns>integer</returns>
        public int CompareTo(DetailedMovie other)
        {
            int result = this.Title.CompareTo(other.Title);

            return result;
        }

    }
}
