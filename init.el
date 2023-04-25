;;; Erlang --- stuff
(setq load-path (cons  "/usr/share/doc/otp/lib/tools-<ToolsVer>/emacs" load-path))
(setq erlang-root-dir "/usr/share/doc/otp")
(setq exec-path (cons "/usr/share/doc/otp/bin" exec-path))
;;(require 'erlang-start)
;;; Commentary:

;;; Code:
(setq ido-auto-merge-delay-time 1)

(setq-default indent-tabs-mode nil)
(setq make-backup-files nil) ; stop creating backup~ files
(setq auto-save-default nil) ; stop creating #autosave# files
;(add-to-list 'default-frame-alist '(font . "Monospace Bold-14"))


;; Deletes all trailing whitespace
(add-hook 'before-save-hook 'delete-trailing-whitespace)


;; LaTeX spell checking
(dolist (hook '(text-mode-hook))
  (add-hook hook (lambda () (flyspell-mode 1))))
 (setq ispell-dictionary "british")

(add-to-list 'default-frame-alist '(fullscreen . maximized))

;; Haskell stuff
(require 'package)
(custom-set-variables
 ;; custom-set-variables was added by Custom.
 ;; If you edit it by hand, you could mess it up, so be careful.
 ;; Your init file should contain only one such instance.
 ;; If there is more than one, they won't work right.
 '(ansi-color-faces-vector
   [default default default italic underline success warning error])
 '(column-number-mode t)
 '(custom-enabled-themes (quote (misterioso)))
 '(package-archives
   (quote
    (("gnu" . "https://elpa.gnu.org/packages/")
     ("melpa" . "https://melpa.org/packages/"))))
 '(package-selected-packages
   (quote
    (## ein rainbow-delimiters minimap erlang elpy intero haskell-emacs haskell-mode move-text drag-stuff auto-complete multiple-cursors fsharp-mode)))
 '(show-paren-mode t)
 '(tool-bar-mode nil))
(package-initialize)

;;(ac-config-default)

;; Back tabbing
(global-set-key (kbd "<backtab>") 'un-indent-by-removing-4-spaces)
(defun un-indent-by-removing-4-spaces ()
  "Remove 4 spaces from beginning of of line."
  (interactive)
  (save-excursion
    (save-match-data
      (beginning-of-line)
      ;; get rid of tabs at beginning of line
      (when (looking-at "^\\s-+")
        (untabify (match-beginning 0) (match-end 0)))
      (when (looking-at "^    ")
        (replace-match "")))))

;; Move an entire line or selection at a time
(defun move-line-up ()
  "Move up the current line."
  (interactive)
  (transpose-lines 1)
  (forward-line -2)
  (indent-according-to-mode))

(defun move-line-down ()
  "Move down the current line."
  (interactive)
  (forward-line 1)
  (transpose-lines 1)
  (forward-line -1)
  (indent-according-to-mode))

(global-unset-key (kbd "C-M-p"))
(global-unset-key (kbd "C-M-n"))
(global-set-key (kbd "C-M-p")  'move-line-up)
(global-set-key (kbd "C-M-n")  'move-line-down)

;;(global-set-key [M-p] 'move-text-up)
;;(global-set-key [M-n] 'move-text-down)

;; Multiline editing
;;(require 'multiple-cursors)
(global-set-key (kbd "C-s-c") 'mc/edit-lines)
(global-set-key (kbd "C-s-n") 'mc/mark-next-like-this)
(global-set-key (kbd "C-s-p") 'mc/mark-previous-like-this)
(global-set-key (kbd "C-s-a") 'mc/mark-all-like-this)

;;(global-auto-revert-mode t)

;;; RECOMMENDED SETTINGS

;;; Initialize MELPA
(require 'package)
(add-to-list 'package-archives '("melpa" . "http://melpa.org/packages/"))
(unless package-archive-contents (package-refresh-contents))
(package-initialize)

;;; Install fsharp-mode
(unless (package-installed-p 'fsharp-mode)
  (package-install 'fsharp-mode))

(require 'fsharp-mode)


(unless (package-installed-p 'multiple-cursors)
  (package-install 'multiple-cursors))


;; Rainbow delimiters
;;(require 'rainbow-delimiters)
(add-hook 'prog-mode-hook #'rainbow-delimiters-mode)

;;Default Directory
(setq default-directory "~/skolearbejde/" )

;;; column numbers
(column-number-mode 1)

;;; line numbers in the side bar
(global-linum-mode 1)

;; Wrapping by words instead of letters
(global-visual-line-mode 1)


;;; hide the gnu startup screen
(setq inhibit-startup-screen 1)

;; Keep a list of recently opened files, and set F7 to list recently opened file
(recentf-mode 1)
(global-set-key (kbd "<f7>") 'recentf-open-files)

;; highlight matching parantheses
(show-paren-mode 1)

;;; FSHARP SETTINGS

(add-to-list 'auto-mode-alist '("\\.fs[iylx]?$" . fsharp-mode))

;; NB: These following two lines should contain the correct path to the
;; fsharp executables (which depends on operating system).
(setq inferior-fsharp-program "/usr/bin/fsharpi --readline-")
(setq fsharp-compiler "/usr/bin/fsharpc")

(add-to-list 'load-path "path/to/futhark-mode")
(require 'futhark-mode)

;;; Flycheck --- syntax highlighting for several languages
(add-hook 'after-init-hook #'global-flycheck-mode)

;;; F#
(flycheck-define-checker fsharp-check
  "Fsharp syntax checker."
  ;; Lazy command - run compiler in module mode
  :command ("fsc" "--target:module" source)

  ;; /path/to/X.fs(7,23): error FS0001: This expression was expected to have type\n
  ;;    int -> int option\n
  ;;  but here has type\n
  ;;    int\n
  ;; \n
  ;; TODO: better indentation below
  :error-patterns
  ((error line-start (file-name) "(" line "," column "): error "
          (message (and (one-or-more not-newline) "\n" (zero-or-more (and (one-or-more not-newline) "\n")) (or "\n" buffer-end))))

   (warning line-start (file-name) "(" line "," column "): warning "
            (message (and (one-or-more not-newline) "\n" (zero-or-more (and (one-or-more not-newline) "\n")) (or "\n" buffer-end))))
   )
  :modes fsharp-mode)
(setq flycheck-fsharp-check-executable "/usr/bin/fsharpc")
(add-to-list 'flycheck-checkers 'fsharp-check)

;; scroll one line at a time (less "jumpy" than defaults)

(setq mouse-wheel-scroll-amount '(2 ((shift) . 1))) ;; one line at a time

(setq mouse-wheel-progressive-speed nil) ;; don't accelerate scrolling

(setq mouse-wheel-follow-mouse 't) ;; scroll window under mouse

(setq scroll-step 1) ;; keyboard scroll one line at a time

;;; OPTIONAL SETTINGS (settings are disabled if line begins with a semicolon ;)

;;; These are outcommented because they may be confusing for new Emacs users,
;;; but included because they are very useful.
;; (menu-bar-mode 1)
(tool-bar-mode -1)
(menu-bar-mode -1)
;; (blink-cursor-mode -1)
(ido-mode 1) ;; press Alt-X to see the difference ;)

(custom-set-faces
 ;; custom-set-faces was added by Custom.
 ;; If you edit it by hand, you could mess it up, so be careful.
 ;; Your init file should contain only one such instance.
 ;; If there is more than one, they won't work right.
 '(default ((t (:family "Dejavu Sans Mono" :foundry "PfEd" :slant normal :weight bold :height 130 :width normal)))))
(provide 'init)
;;; init.el ends here
