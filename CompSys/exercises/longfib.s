	.file	"longfib.c"
	.text
	.globl	fib
	.type	fib, @function
fib:
.LFB0:
	.cfi_startproc
	cmpq	$1, %rdi
	jle	.L3
	pushq	%rbp
	.cfi_def_cfa_offset 16
	.cfi_offset 6, -16
	pushq	%rbx
	.cfi_def_cfa_offset 24
	.cfi_offset 3, -24
	subq	$8, %rsp
	.cfi_def_cfa_offset 32
	movq	%rdi, %rbx
	leaq	-1(%rdi), %rdi
	call	fib
	movq	%rax, %rbp
	leaq	-2(%rbx), %rdi
	call	fib
	addq	%rbp, %rax
	addq	$8, %rsp
	.cfi_def_cfa_offset 24
	popq	%rbx
	.cfi_def_cfa_offset 16
	popq	%rbp
	.cfi_def_cfa_offset 8
	ret
.L3:
	.cfi_restore 3
	.cfi_restore 6
	movl	$1, %eax
	ret
	.cfi_endproc
.LFE0:
	.size	fib, .-fib
	.ident	"GCC: (GNU) 8.2.1 20180831"
	.section	.note.GNU-stack,"",@progbits
