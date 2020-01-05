(setq-default indent-tabs-mode nil)
(setq make-backup-files nil) ; stop creating backup~ files
(setq auto-save-default nil) ; stop creating #autosave# files
(add-to-list 'default-frame-alist '(font . "Monospace Bold-10"))

;; Deletes all trailing whitespace
(add-hook 'before-save-hook 'delete-trailing-whitespace)

;;(ac-config-default)

;; Back tabbing
(global-set-key (kbd "<backtab>") 'un-indent-by-removing-4-spaces)
(defun un-indent-by-removing-4-spaces ()
  "remove 4 spaces from beginning of of line"
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
;;(move-text-default-bindings)
(global-set-key [M-p] 'move-text-up)
(global-set-key [M-n] 'move-text-down)

;; Multiline editing
;;(require 'multiple-cursors)
(global-set-key (kbd "C-s-c") 'mc/edit-lines)
(global-set-key (kbd "C-<") 'mc/mark-next-like-this)
(global-set-key (kbd "C->") 'mc/mark-previous-like-this)
(global-set-key (kbd "C-c C-<") 'mc/mark-all-like-this)

;;(global-auto-revert-mode t)

;;; RECOMMENDED SETTINGS

;;; package archives
(require 'package)
(add-to-list 'package-archives '("melpa" . "http://melpa.milkbox.net/packages/"))
(unless package-archive-contents (package-refresh-contents))
(package-initialize)

;;Default Directory
(setq default-directory "/home/casper/skolearbejde/" )

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

(unless (package-installed-p 'fsharp-mode)
  (package-install 'fsharp-mode))

(require 'fsharp-mode)

(add-to-list 'auto-mode-alist '("\\.fs[iylx]?$" . fsharp-mode))

;; NB: These following two lines should contain the correct path to the
;; fsharp executables (which depends on operating system).
(setq inferior-fsharp-program "/usr/bin/fsharpi --readline-")
(setq fsharp-compiler "/usr/bin/fsharpc")

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
;; (blink-cursor-mode -1)
(ido-mode 1) ;; press Alt-X to see the difference ;)
(custom-set-variables
 ;; custom-set-variables was added by Custom.
 ;; If you edit it by hand, you could mess it up, so be careful.
 ;; Your init file should contain only one such instance.
 ;; If there is more than one, they won't work right.
 '(ansi-color-faces-vector
   [default default default italic underline success warning error])
 '(column-number-mode t)
 '(custom-enabled-themes (quote (misterioso)))
 '(package-selected-packages
   (quote
    (move-text drag-stuff auto-complete multiple-cursors fsharp-mode)))
 '(show-paren-mode t)
 '(tool-bar-mode nil))
(custom-set-faces
 ;; custom-set-faces was added by Custom.
 ;; If you edit it by hand, you could mess it up, so be careful.
 ;; Your init file should contain only one such instance.
 ;; If there is more than one, they won't work right.
 '(default ((t (:family "DejaVu Sans Mono" :foundry "PfEd" :slant normal :weight bold :height 90 :width normal)))))
