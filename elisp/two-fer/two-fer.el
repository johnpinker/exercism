;;; two-fer.el --- Two-fer Exercise (exercism)

;;; Commentary:

;;; Code:

(defun two-fer (&optional pname)
  (if (eq nil pname) (setq pname "you"))
  (concat "One for " pname ", one for me.")
  )

(provide 'two-fer)
;;; two-fer.el ends here
