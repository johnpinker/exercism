;;; bob.el --- Bob exercise (exercism)

;;; Commentary:

;;; Code:

(require 'subr-x)

(defun response-for (message)

  (setq message (string-trim message))
  (if (> (length message) 0)
      (setq punc (substring message (- (length message) 1) (length message)))
    (setq punc "")
    )
  (if
      (eq (length message) 0)
      (setq isempty t)
    (setq isempty nil)
    ) 
  (if
      (and
       (string= message (upcase message))
       (not (string= message (downcase message)))
       )
      (setq upper t)
    (setq upper nil)
    )

  (cond
   ((and (string= punc "?") (eq upper t))  (concat "Calm down, I know what I'm doing!"))
   ((string= punc "?") (concat "Sure."))
   ((eq isempty t) (concat "Fine. Be that way!"))
   ((eq upper t) (concat  "Whoa, chill out!"))
   (t (concat "Whatever."))
   )
  )
  
(provide 'bob)
;;; bob.el ends here
