# RxApp

## Quiz

Implement a secret lock whereby
- the moment the toggle is toggled on, 
    - if the text entry is "hey"
    - if the slider is greater than 0.5,
- the button would be enabled for 5 sec.



Hints:
- ReactiveCommand.CreateFromObservable can take be bound to a UI action via ICommand interface.
- It also takes a CanExecute observable
  