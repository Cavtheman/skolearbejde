	.file	"noAs.c"
	.text
	.section	.rodata.str1.1,"aMS",@progbits,1
.LC0:
	.string	"No beginning A's are allowed"
	.text
	.globl	main
	.type	main, @function
main:
.LFB22:
	.cfi_startproc
	cmpl	$2, %edi
	je	.L8
	movl	$0, %eax
	ret
.L8:
	subq	$8, %rsp
	.cfi_def_cfa_offset 16
	movq	8(%rsi), %rdi
	cmpb	$65, (%rdi)
	je	.L9
	call	puts@PLT
.L2:
	movl	$0, %eax
	addq	$8, %rsp
	.cfi_remember_state
	.cfi_def_cfa_offset 8
	ret
.L9:
	.cfi_restore_state
	leaq	.LC0(%rip), %rdi
	call	puts@PLT
	jmp	.L2
	.cfi_endproc
.LFE22:
	.size	main, .-main
	.ident	"GCC: (GNU) 8.2.1 20180831"
	.section	.note.GNU-stack,"",@progbits
