import logging
import threading
import time
import queue
import Get


def thread_function(name , q):
    logging.info("Thread %s: starting", name)
    time.sleep(2)
    logging.info("Thread %s: finishing", name)
    res = "1234"
    q.put(res)
    return "123"

if __name__ == "__main__":
    format = "%(asctime)s: %(message)s"
    logging.basicConfig(format=format, level=logging.INFO,
                        datefmt="%H:%M:%S")

    logging.info("Main    : before creating thread")
    q = queue.Queue()
    x = threading.Thread(target=Get.GetUserInfo, args=("123456",q),)
    x.start()
    logging.info("Main    : before running thread")
    y = q.get()
    
    logging.info("Main    : wait for the thread to finish")
    # x.join()
    logging.info("Main    : all done")

    print(y)