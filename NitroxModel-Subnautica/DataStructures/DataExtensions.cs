﻿using System;
using NitroxModel.DataStructures;
using NitroxModel.DataStructures.GameLogic;
using NitroxModel.DataStructures.Unity;
using NitroxModel.Packets;
using UnityEngine;

namespace NitroxModel_Subnautica.DataStructures
{
    public static class DataExtensions
    {
        public static Int3 ToUnity(this NitroxInt3 v)
        {
            return new Int3(v.X, v.Y, v.Z);
        }

        public static NitroxInt3 ToDto(this Int3 v)
        {
            return new NitroxInt3(v.x, v.y, v.z);
        }

        public static NitroxVector3 ToDto(this Vector3 v)
        {
            return new NitroxVector3(v.x, v.y, v.z);
        }

        public static Vector3 ToUnity(this NitroxVector3 v)
        {
            return new Vector3(v.X, v.Y, v.Z);
        }

        public static NitroxTechType ToDto(this TechType v)
        {
            return new NitroxTechType(v.ToString());
        }

        public static TechType ToUnity(this NitroxTechType v)
        {
            return (TechType)Enum.Parse(typeof(TechType), v.Name);
        }

        public static Quaternion ToUnity(this NitroxQuaternion v)
        {
            return new Quaternion(v.X, v.Y, v.Z, v.W);
        }

        public static NitroxQuaternion ToDto(this Quaternion v)
        {
            return new NitroxQuaternion(v.x, v.y, v.z, v.w);
        }

        public static NitroxColor ToDto(this Color v)
        {
            return new NitroxColor(v.r, v.g, v.b, v.a);
        }

        public static Color ToUnity(this NitroxColor v)
        {
            return new Color(v.R, v.G, v.B, v.A);
        }

        public static NitroxColor[] ToDto(this Color[] v)
        {
            NitroxColor[] result = new NitroxColor[v.Length];
            for (int i = 0; i < v.Length; i++)
            {
                result[i] = v[i].ToDto();
            }
            return result;
        }

        public static NitroxVector3[] ToDto(this Vector3[] v)
        {
            if (v == null)
            {
                return new NitroxVector3[0];
            }

            NitroxVector3[] result = new NitroxVector3[v.Length];
            for (int i = 0; i < v.Length; i++)
            {
                result[i] = v[i].ToDto();
            }
            return result;
        }

        public static Vector3[] ToUnity(this NitroxVector3[] v)
        {
            if (v == null)
            {
                return new Vector3[0];
            }

            Vector3[] result = new Vector3[v.Length];
            for (int i = 0; i < v.Length; i++)
            {
                result[i] = v[i].ToUnity();
            }
            return result;
        }

        public static StoryEventSend.EventType ToDto(this Story.GoalType goalType)
        {
            return goalType switch
            {
                Story.GoalType.PDA => StoryEventSend.EventType.PDA,
                Story.GoalType.Radio => StoryEventSend.EventType.RADIO,
                Story.GoalType.Encyclopedia => StoryEventSend.EventType.ENCYCLOPEDIA,
                Story.GoalType.Story => StoryEventSend.EventType.STORY,
                _ => throw new ArgumentException("The provided Story.GoalType doesn't correspond to a StoryEventSend.EventType"),
            };
        }

        public static Story.GoalType ToUnity(this StoryEventSend.EventType eventType)
        {
            return eventType switch
            {
                StoryEventSend.EventType.PDA => Story.GoalType.PDA,
                StoryEventSend.EventType.RADIO => Story.GoalType.Radio,
                StoryEventSend.EventType.ENCYCLOPEDIA => Story.GoalType.Encyclopedia,
                StoryEventSend.EventType.STORY => Story.GoalType.Story,
                _ => throw new ArgumentException("The provided StoryEventSend.EventType doesn't correspond to a Story.GoalType")
            };
        }
    }
}
