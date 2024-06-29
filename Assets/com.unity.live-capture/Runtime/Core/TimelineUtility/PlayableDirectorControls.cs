using System;
using UnityEngine.Playables;
using Unity.LiveCapture.Internal;

namespace Unity.LiveCapture
{
    /// <summary>
    /// A collection of methods to control a PlayableDirector abstracting away the timeline hierarchy.
    /// </summary>
    class PlayableDirectorControls
    {
        /// <summary>
        /// Plays a PlayableDirector.
        /// </summary>
        /// <remarks>
        /// This method abstracts away any timeline hierarchy the PlayableDirector my be sitting in.
        /// </remarks>
        /// <param name="director">The PlayableDirector play.</param>
        public static void Play(PlayableDirector director)
        {
            if (director == null)
                throw new ArgumentNullException(nameof(director));

            var root = TimelineHierarchy.GetRootDirector(director);

            PlayableDirectorInternal.ResetFrameTiming();

            root.Play();
        }

        /// <summary>
        /// Pauses a PlayableDirector.
        /// </summary>
        /// <remarks>
        /// This method abstracts away any timeline hierarchy the PlayableDirector my be sitting in.
        /// </remarks>
        /// <param name="director">The PlayableDirector pause.</param>
        public static void Pause(PlayableDirector director)
        {
            if (director == null)
                throw new ArgumentNullException(nameof(director));

            var root = TimelineHierarchy.GetRootDirector(director);

            root.Pause();
        }

        /// <summary>
        /// Sets the time of a PlayableDirector by converting and setting it to the root PlayableDirector.
        /// </summary>
        /// <remarks>
        /// The provided time is local to the provided PlayableDirector,
        /// and it gets converted to time relative to the root PlayableDirector.
        /// </remarks>
        /// <param name="director">The PlayableDirector to set the time to.</param>
        /// <param name="time">The time to set local to the PlayableDirector.</param>
        public static void SetTime(PlayableDirector director, double time)
        {
            if (director == null)
                throw new ArgumentNullException(nameof(director));

            while (TimelineHierarchy.TryGetParentContext(director, out var parentDirector, out var parentClip))
            {
                time = MathUtility.Clamp(time, 0f, parentClip.duration) + parentClip.start;
                director = parentDirector;
            }
            
            director.Pause();
            director.time = time;
            director.DeferredEvaluate();
        }
    }
}
