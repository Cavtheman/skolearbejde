import matplotlib.pyplot as plt
import numpy as np
import scipy.stats as sp
import random
random.seed(1337)


# Loading the data from a .txt file with columns: line_num, eruption time, wait time
def read_data(filename):
    eruption = []
    wait = []
    with open(filename, 'r', encoding='utf-8') as file:
        lines = file.readlines()
    for line in lines:
        nums = line.split()
        eruption.append(float(nums[1]))
        wait.append(int(nums[2]))
    return np.array([eruption, wait])


data = read_data("old_faithful.txt")

def expectation(data, k, sigma, means, cluster_probs):
    gamma = np.empty((data.shape[1],k))
    # Looping through k
    for i in range(gamma.shape[1]):
        # Looping through n
        for j in range(gamma.shape[0]):
            num = cluster_probs[i] * sp.multivariate_normal.pdf(data[:,j], means[i], sigma[i])
            den = 0
            # Looping through k'
            for l in range(gamma.shape[1]):
                den += cluster_probs[l] * sp.multivariate_normal.pdf(data[:,j], means[l], sigma[l]) + 1e-8
            gamma[j,i] = num/den + 1e-8
    return gamma

def maximization(data, cluster_probs, gamma, k, sigma, means):
    n_k = np.empty(k)
    # Updating N_k
    for i in range(gamma.shape[1]):
        n_k[i] = np.sum(gamma[:,i]) + 1e-8

    # Updating pi_k
    for i in range(n_k.shape[0]):
        cluster_probs[i] = n_k[i] / gamma.shape[0]

    for i in range(gamma.shape[1]):
        #plt.scatter(means[:,0], means[:,1], marker='+')
        # Updating mu_k
        means[i] = np.sum(gamma[:,i] * data, axis=1)/n_k[i]
        # Updating sigma_k
        sigma[i] = (gamma[:,i] * (data.T - means[i]).T) @ (data.T - means[i]) / n_k[i]

    return means, sigma, cluster_probs


def em(data, k, max_iter=500, save_plots=False):
    # Initialising Sigma
    temp_sigma = [np.identity(2) for i in range(k)]
    sigma = np.stack(temp_sigma)

    # Initialising means
    xmeans = np.random.choice(data[0,:], k)
    ymeans = np.random.choice(data[1,:], k)
    means = np.array([xmeans, ymeans]).T

    # Initialising pi_k
    cluster_probs = np.full(k,1/k)

    # Initialising miscellaneous stuff
    converged = False
    iterations = 0
    log_likelihood = 0
    likelihood_list = []
    means_list = []


    while not converged and iterations <= max_iter:
        # Expectation and maximization
        gamma = expectation(data, k, sigma, means, cluster_probs)
        means_list.append(means.copy())
        #print("Means:", means)
        #print("Pi_k", cluster_probs)
        means, sigma, cluster_probs = maximization(data, cluster_probs, gamma, k, sigma, means)

        # Calculating Log Likelihood
        prev_log_like = log_likelihood

        log_likelihood = 0
        for j in range(data.shape[0]):
            den = 0
            # Looping through k'
            for l in range(gamma.shape[1]):
                den += cluster_probs[l] * sp.multivariate_normal.pdf(data[:,j], means[l], sigma[l])
            log_likelihood += np.log(den)

        # Convergence
        # print(prev_log_like - log_likelihood)
        if (abs(prev_log_like - log_likelihood) < 1e-10):
            print("Converged after {0} iterations".format(iterations))
            converged = True
        iterations += 1
        likelihood_list.append(log_likelihood)
        if (iterations >= max_iter):
            print("Did not converge after {0} iterations".format(iterations))

        # Plotting heatmap of distribution
        fig = plt.figure()#figsize=(6,5))
        left, bottom, width, height = 0.1, 0.1, 0.8, 0.8
        ax = fig.add_axes([left, bottom, width, height])

        start, stop, n_values = 0, 100, 100

        x_vals = np.linspace(min(data[0]), max(data[0]), n_values)
        y_vals = np.linspace(min(data[1]), max(data[1]), n_values)
        X, Y = np.meshgrid(x_vals, y_vals)
        l = 0

        f = lambda x, y: np.sum([cluster_probs[l] * sp.multivariate_normal.pdf([x_vals[int(x)],y_vals[int(y)]], means[l], sigma[l]) for l in range(k)])
        Z = np.fromfunction(np.vectorize(f), (n_values,n_values)).T
        cp = plt.contourf(X, Y, Z)
        plt.colorbar(cp)

        ax.set_title('Iteration {0}'.format(iterations))
        ax.set_xlabel('Eruption duration')
        ax.set_ylabel('Time between eruptions')
        #plt.show()
        if (save_plots):
            plt.savefig("report/contour{0}".format(iterations))



    # Plotting base data
    plt.scatter(data[0,:], data[1,:], marker='.')

    # Plotting final mean values
    plt.scatter(means[:,0], means[:,1], marker='x')
    temp = np.asarray(means_list)
    base_colors=['blue', 'orange', 'red']
    for i in range(k):
        if (i > 2):
            random_number = random.randint(0,16777215)
            hex_number = str(hex(random_number))
            hex_number ='#'+ hex_number[2:]
        else:
            hex_number = base_colors[i]
        plt.scatter(temp[:,i,0], temp[:,i,1], color=hex_number)
        plt.plot(temp[:,i,0], temp[:,i,1], label="Path of means for k = {0}".format(i+1), color=hex_number)
    plt.legend()
    if (save_plots):
        plt.savefig("report/path")
    plt.show()

    # Plotting log likelihood
    plt.plot(likelihood_list)
    plt.scatter(range(len(likelihood_list)),likelihood_list)
    plt.xlabel("Iteration")
    plt.ylabel("Log Likelihood")
    #plt.show()
    if (save_plots):
        plt.savefig("report/log_likelihood")
    plt.show()



em(data, 3, 75, False)
