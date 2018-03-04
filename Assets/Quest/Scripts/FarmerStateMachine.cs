using System;
using UnityEngine;

public enum FarmerState
{
    Idle,
    Hello,
    Offer,
    Random,
    Success,
    Fail,
    Accept,
    WaitingInput
}

public class FarmerStateMachine
{
    FarmerState currentFarmerState = FarmerState.Idle;

    public FarmerState CurrentFarmerState
    {
        get { return currentFarmerState; }
        set { currentFarmerState = value; }
    }

    FarmerQuest farmerQuest;

    public FarmerStateMachine(FarmerQuest farmerQuest)
    {
        this.farmerQuest = farmerQuest;
    }

    public void ProcessInput()
    {
        switch (currentFarmerState)
        {
            case FarmerState.Idle:
                Idle();
                break;
            case FarmerState.Hello:
                Hello();
                break;
            case FarmerState.WaitingInput:
                GetNextState();
                break;
            case FarmerState.Offer:
                Offer();
                break;
            case FarmerState.Random:
                ExitOnInput();
                break;
            case FarmerState.Success:
                ExitAndSuccess();
                break;
            case FarmerState.Fail:
                ExitAndFail();
                break;
            case FarmerState.Accept:
                ExitOnInput();
                break;
            default:
                break;
        }
    }

    private void Idle()
    {
        if (farmerQuest.IsInteracting)
        {
            currentFarmerState = FarmerState.Hello;
        }
    }

    private void ExitAndFail()
    {
        if (PlayerSpec.pressSubmit || PlayerSpec.pressCancel)
        {
            CloseDialogWindow();
            farmerQuest.Fail();
        }
    }

    private void ExitAndSuccess()
    {
        if (PlayerSpec.pressSubmit || PlayerSpec.pressCancel)
        {
            CloseDialogWindow();
            farmerQuest.Success();
        }
    }

    private void Offer()
    {
        if (PlayerSpec.pressSubmit)
        {
            farmerQuest.AcceptQuest();

            // show the dialog for the accept
            farmerQuest.ShowAcceptText();

            currentFarmerState = FarmerState.Accept;
        }

        if (PlayerSpec.pressCancel)
        {            
            CloseDialogWindow();
        }
    }

    private void ExitOnInput()
    {
        if (PlayerSpec.pressSubmit || PlayerSpec.pressCancel)
        {
            CloseDialogWindow();
        }
    }

    private void Hello()
    {
        // we pick a quest if we don't have one
        if (farmerQuest.Quest == null)
        {
            farmerQuest.PickRandomQuest();
        }

        farmerQuest.ShowHelloText();

        // Go To Random
        currentFarmerState = FarmerState.WaitingInput;
    }

    private void GetNextState()
    {
        if (PlayerSpec.pressSubmit)
        {
            if (farmerQuest.QuestManager.IsOnMission)
            {
                // show the dialog for the quest
                farmerQuest.ShowRandomText();

                // Go To Random
                currentFarmerState = FarmerState.Random;
            }
            else if (!farmerQuest.QuestManager.IsOnMission && !farmerQuest.Quest.IsDone)
            {
                // show the dialog for the quest
                farmerQuest.ShowQuestText();

                // Go To Offer
                currentFarmerState = FarmerState.Offer;
            }
            else if (farmerQuest.Quest.IsDone && farmerQuest.Quest.IsSuccess)
            {
                // show the dialog for the quest
                farmerQuest.ShowSuccessText();

                // Go To Success
                currentFarmerState = FarmerState.Success;
            }
            else if (farmerQuest.Quest.IsDone && !farmerQuest.Quest.IsSuccess)
            {
                // show the dialog for the quest
                farmerQuest.ShowFailText();

                // Go To Fail
                currentFarmerState = FarmerState.Fail;
            }
        }
        
        if (PlayerSpec.pressCancel)
        {
            // close dialog window
            CloseDialogWindow();
        }
    }

    private void CloseDialogWindow()
    {
        farmerQuest.StopTalking();
        PlayerSpec.canMove = true;
        farmerQuest.IsInteracting = false;

        currentFarmerState = FarmerState.Idle;
    }
}
