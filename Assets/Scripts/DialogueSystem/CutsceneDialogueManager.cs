using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneDialogueManager : MonoBehaviour
{
    public TMP_Text[] textBox;
    public AudioClip typingClip;
    public AudioSourceGroup audioSourceGroup;
    public bool[] finishedAnimating;
    public bool Speedup;

    // public Button playDialogue1Button;
    // public Button playDialogue2Button;
    // public Button playDialogue3Button;

    [TextArea]
    public string dialogue1;
    [TextArea]
    public string dialogue2;
    [TextArea]
    public string dialogue3;
    [TextArea]
    public string dialogue4;
    [TextArea]
    public string dialogue5;
    [TextArea]
    public string dialogue6;
    [TextArea]
    public string dialogue7;
    [TextArea]
    public string dialogue8;
    [TextArea]
    public string dialogue9;
    [TextArea]
    public string dialogue10;
    [TextArea]
    public string dialogue11;
    [TextArea]
    public string dialogue12;
    [TextArea]
    public string dialogue13;
    [TextArea]
    public string dialogue14;
    [TextArea]
    public string dialogue15;
    [TextArea]
    public string dialogue16;
    [TextArea]
    public string dialogue17;
    [TextArea]
    public string dialogue18;
    [TextArea]
    public string dialogue19;
    [TextArea]
    public string dialogue20;
    [TextArea]
    public string dialogue21;
    [TextArea]
    public string dialogue22;
    [TextArea]
    public string dialogue23;
    [TextArea]
    public string dialogue24;
    [TextArea]
    public string dialogue25;
    [TextArea]
    public string dialogue26;

    public CutsceneManager intromanager;


    public DialogueVertexAnimator dialogueVertexAnimator;
    void Awake() {
        
        finishedAnimating = new bool[textBox.Length];
    
        
        // playDialogue1Button.onClick.AddListener(delegate { PlayDialogue1(); });
        // playDialogue2Button.onClick.AddListener(delegate { PlayDialogue2(); });
        // playDialogue3Button.onClick.AddListener(delegate { PlayDialogue3(); });
    }

    void Update(){

        // foreach(TMP_text Text in textBox)
        // {
        //     if(dialogueVertexAnimator != null && dialogueVertexAnimator.textBox == Text )
        //     {
        //         finishedAnimating = dialogueVertexAnimator.FinishedAnimating;
        //     }
        // }

        for(int x = 0; x<=textBox.Length-1; x++)
        {
            if(dialogueVertexAnimator != null && dialogueVertexAnimator.textBox == textBox[x] )
            {
                finishedAnimating[x] = dialogueVertexAnimator.FinishedAnimating;
            }
        }
        
    }

    public void PlayDialogue1() {
        dialogueVertexAnimator = new DialogueVertexAnimator(textBox[0], audioSourceGroup);
        PlayDialogue(dialogue1);
    }

    public void PlayDialogue2() {
        dialogueVertexAnimator = new DialogueVertexAnimator(textBox[1], audioSourceGroup);
        PlayDialogue(dialogue2);
    }

    public void PlayDialogue3() {
        dialogueVertexAnimator = new DialogueVertexAnimator(textBox[2], audioSourceGroup);
        PlayDialogue(dialogue3);
    }

    public void PlayDialogue4() {
        dialogueVertexAnimator = new DialogueVertexAnimator(textBox[3], audioSourceGroup);
        PlayDialogue(dialogue4);
    }

    public void PlayDialogue5() {
        dialogueVertexAnimator = new DialogueVertexAnimator(textBox[4], audioSourceGroup);
        PlayDialogue(dialogue5);
    }

    public void PlayDialogue6() {
        dialogueVertexAnimator = new DialogueVertexAnimator(textBox[5], audioSourceGroup);
        PlayDialogue(dialogue6);
    }

    public void PlayDialogue7() {
        dialogueVertexAnimator = new DialogueVertexAnimator(textBox[6], audioSourceGroup);
        PlayDialogue(dialogue7);
    }

    public void PlayDialogue8() {
        dialogueVertexAnimator = new DialogueVertexAnimator(textBox[7], audioSourceGroup);
        PlayDialogue(dialogue8);
    }
    public void PlayDialogue9() {
        dialogueVertexAnimator = new DialogueVertexAnimator(textBox[8], audioSourceGroup);
        PlayDialogue(dialogue9);
    }
    public void PlayDialogue10() {
        dialogueVertexAnimator = new DialogueVertexAnimator(textBox[9], audioSourceGroup);
        PlayDialogue(dialogue10);
    }
    public void PlayDialogue11() {
        dialogueVertexAnimator = new DialogueVertexAnimator(textBox[10], audioSourceGroup);
        PlayDialogue(dialogue11);
    }
    public void PlayDialogue12() {
        dialogueVertexAnimator = new DialogueVertexAnimator(textBox[11], audioSourceGroup);
        PlayDialogue(dialogue12);
    }
    public void PlayDialogue13() {
        dialogueVertexAnimator = new DialogueVertexAnimator(textBox[12], audioSourceGroup);
        PlayDialogue(dialogue13);
    }
    public void PlayDialogue14() {
        dialogueVertexAnimator = new DialogueVertexAnimator(textBox[13], audioSourceGroup);
        PlayDialogue(dialogue14);
    }
    public void PlayDialogue15() {
        dialogueVertexAnimator = new DialogueVertexAnimator(textBox[14], audioSourceGroup);
        PlayDialogue(dialogue15);
    }
    public void PlayDialogue16() {
        dialogueVertexAnimator = new DialogueVertexAnimator(textBox[15], audioSourceGroup);
        PlayDialogue(dialogue16);
    }

    public void PlayDialogue17() {
        dialogueVertexAnimator = new DialogueVertexAnimator(textBox[16], audioSourceGroup);
        PlayDialogue(dialogue17);
    }

    public void PlayDialogue18() {
        dialogueVertexAnimator = new DialogueVertexAnimator(textBox[17], audioSourceGroup);
        PlayDialogue(dialogue18);
    }

    public void PlayDialogue19() {
        dialogueVertexAnimator = new DialogueVertexAnimator(textBox[18], audioSourceGroup);
        PlayDialogue(dialogue19);
    }

    public void PlayDialogue20() {
        dialogueVertexAnimator = new DialogueVertexAnimator(textBox[19], audioSourceGroup);
        PlayDialogue(dialogue20);
    }

    public void PlayDialogue21() {
        dialogueVertexAnimator = new DialogueVertexAnimator(textBox[20], audioSourceGroup);
        PlayDialogue(dialogue21);
    }

    public void PlayDialogue22() {
        dialogueVertexAnimator = new DialogueVertexAnimator(textBox[21], audioSourceGroup);
        PlayDialogue(dialogue22);
    }

    public void PlayDialogue23() {
        dialogueVertexAnimator = new DialogueVertexAnimator(textBox[22], audioSourceGroup);
        PlayDialogue(dialogue23);
    }

    public void PlayDialogue24() {
        dialogueVertexAnimator = new DialogueVertexAnimator(textBox[23], audioSourceGroup);
        PlayDialogue(dialogue24);
    }

    public void PlayDialogue25() {
        dialogueVertexAnimator = new DialogueVertexAnimator(textBox[24], audioSourceGroup);
        PlayDialogue(dialogue25);
    }
    


    private Coroutine typeRoutine = null;
    void PlayDialogue(string message) {
        Speedup = false;
        this.EnsureCoroutineStopped(ref typeRoutine);
        dialogueVertexAnimator.textAnimating = false;
        List<DialogueCommand> commands = DialogueUtility.ProcessInputString(message, out string totalTextMessage);
        typeRoutine = StartCoroutine(dialogueVertexAnimator.AnimateTextIn(commands, totalTextMessage, typingClip, null));

        
    }

    public void SpeedUp()
    {
        dialogueVertexAnimator.stopAnimating = true;
        //IntroManager.SpeedWaitMultiplier = 0.0f;
        Speedup = true;
        
    }
}


