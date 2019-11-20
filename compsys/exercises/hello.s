	.file	"hello.c"
	.text
	.section	.rodata.str1.1,"aMS",@progbits,1
.LC0:
	.string	"Usage: %s argument\n"
.LC1:
	.string	"hello"
.LC2:
	.string	"%s, %s!\n"
	.text
	.globl	main
	.type	main, @function
main:
.LFB22:
	.cfi_startproc
	subq	$8, %rsp
	.cfi_def_cfa_offset 16
	cmpl	$2, %edi
	je	.L2
	movq	(%rsi), %rdx
	leaq	.LC0(%rip), %rsi
	movq	stderr(%rip), %rdi
	movl	$0, %eax
	call	fprintf@PLT
	movl	$1, %eax
.L1:
	addq	$8, %rsp
	.cfi_remember_state
	.cfi_def_cfa_offset 8
	ret
.L2:
	.cfi_restore_state
	movb	$72, .LC1(%rip)
	movq	8(%rsi), %rcx
	leaq	.LC1(%rip), %rdx
	leaq	.LC2(%rip), %rsi
	movq	stdout(%rip), %rdi
	movl	$0, %eax
	call	fprintf@PLT
	movl	$0, %eax
	jmp	.L1
	.cfi_endproc
.LFE22:
	.size	main, .-main
	.ident	"GCC: (GNU) 8.2.1 20180831"
	.section	.note.GNU-stack,"",@progbits
