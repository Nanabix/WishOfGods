Heeey ... Who are you again?#speaker:Marvin #portrait:Marvin_neutral #layout:right
Yuru?

-> main
=main
What can I do for you?#speaker:Marvin #portrait:Marvin_neutral #layout:right
* yeah, It's me. Yuru?#speaker:Yuru #portrait:Yuru_neutral #layout:left
Aaah, I remembered correctly!#speaker:Marvin #portrait:Marvin_neutral #layout:right
->main

* I need tea for mom.#speaker:Yuru #portrait:Yuru_neutral #layout:left
She's not okay, right?#speaker:Marvin #portrait:Marvin_neutral #layout:right
What does she need? 
Some oils? 
Or maybe something new? 
I have a new medicine we could try.
    ** I think she slowly gets better.#speaker:Yuru #portrait:Yuru_neutral #layout:left
    ->Quest
    ** She just needs some tea.#speaker:Yuru #portrait:Yuru_neutral #layout:left
    ->Quest
    ** I don't know... I am worried for her.#speaker:Yuru #portrait:Yuru_neutral #layout:left
    ->Quest

+ Did you see that story teller in Town? He is usually in the Tavern.#speaker:Yuru #portrait:Yuru_neutral #layout:left
Who? #speaker:Marvin #portrait:Marvin_neutral #layout:right
Do you mean Jasper? 
Of course I know him! Always grumpy and these sun glasses! 
How does he even see his fingers with those? I am surprised that he knows what he's grabbin'!
->Jasper

+ Do you know the Legend of the God's Wish?#speaker:Yuru #portrait:Yuru_neutral #layout:left
Hmm … the one about gathering gifts of the gods and then you get one wish? #speaker:Marvin #portrait:Marvin_neutral #layout:right
That’s Bullshit. 
There are no gods anymore, they left us long ago.
->main

+ Okay, see you later!#speaker:Yuru #portrait:Yuru_neutral #layout:left
->END

=Quest
For her medicine I need some herbs from the fields. Wanna get them for me?#speaker:Marvin #portrait:Marvin_neutral #layout:right
***Yeah, Of course.#speaker:Yuru #portrait:Yuru_neutral #layout:left
->main
***Noo, maybe later.#speaker:Yuru #portrait:Yuru_neutral #layout:left
Really?#speaker:Marvin #portrait:Marvin_neutral #layout:right
    ****You are right. I should get them.#speaker:Yuru #portrait:Yuru_neutral #layout:left
    As Always.#speaker:Marvin #portrait:Marvin_neutral #layout:right
    ->main
    **** I will do it later.#speaker:Yuru #portrait:Yuru_neutral #layout:left
    Shame on you. #speaker:Marvin #portrait:Marvin_neutral #layout:right
    Your poor mother.
    You get them for me! 
    Now!
    ->main

=Jasper
++Noo! I mean that mysterious Person!
Yes, yes. Jasper! That grumpy bat, that always tells weird stories!#speaker:Marvin #portrait:Marvin_neutral #layout:right
->Jasper
++ Yes... exactly. Jasper...
Told you.#speaker:Marvin #portrait:Marvin_neutral #layout:right
-> main