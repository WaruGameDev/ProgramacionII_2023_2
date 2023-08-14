using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "WalterSystemDialogue/Character", 
    fileName = "Character", order = 0)]
public class CharacterNovel : ScriptableObject
{
    public string nameCharacter;
    public string descriptionCharacter;
    public Sprite hdNeutral, hdBlush, hdPissed;
    public Sprite huNeutral, huBlush, huPissed;

    public Sprite GetSpriteExpression(EXPRESSION expression, bool headDown)
    {
        if (headDown)
        {
            switch (expression)
            {
                case EXPRESSION.NEUTRAL:
                    return hdNeutral;
                case EXPRESSION.BLUSH:
                    return hdBlush;
                case EXPRESSION.PISSED:
                    return hdPissed;
                default:
                    throw new ArgumentOutOfRangeException(nameof
                        (expression), expression, null);
            }
        }
        else
        {
            switch (expression)
            {
                case EXPRESSION.NEUTRAL:
                    return huNeutral;
                case EXPRESSION.BLUSH:
                    return huBlush;
                case EXPRESSION.PISSED:
                    return huPissed;
                default:
                    throw new ArgumentOutOfRangeException(nameof
                        (expression), expression, null);
            }
        }

        return null;
    }
    
}
