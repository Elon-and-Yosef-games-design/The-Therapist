﻿using OpenAI_API;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace OpenAI_Unity
{
    
    public class OAICharacter : OAICompletion
    {
        protected override StringBuilder GetDefaultInformation()
        {
            var sb = base.GetDefaultInformation();
            sb.Replace("[Subject]", this.characterName);
            sb.Append($"\n\nTherapist: Hi\n{characterName}: Hello\nTherapist: ");

            return sb;
        }
        public override string Description { get => $"The following is appointment conversation between Therapist and {characterName}.\n"; set => throw new System.NotImplementedException(); }

        public override string InjectStartText { get => "\n" + characterName + ":"; set => throw new System.NotImplementedException(); }
        [SerializeField]
        private string characterName = "Emma";

        public override string InjectRestartText { get => "\nTherapist: "; set => throw new System.NotImplementedException(); }

        public override string[] StopSequences { get => new string[] { "\n", "Therapist:" }; set => throw new System.NotImplementedException(); }

        public override int NumOutputs { get => 1; set => throw new NotImplementedException(); }


        private void ThrowError (string value)
        {

            Debug.LogError($"Can not set OAICharacter variable to {value}! If you want to modify these please use an OAISimpleObject instead");
        }

    }
}